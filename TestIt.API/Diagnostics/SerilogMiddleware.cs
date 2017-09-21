using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using TestIt.Business;
using Log = TestIt.Model.Entities.Log;

namespace TestIt.API.Diagnostics
{
    public class SerilogMiddleware
    {
        private const string MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        private static readonly ILogger Log = Serilog.Log.ForContext<SerilogMiddleware>();

        private readonly RequestDelegate _next;

        private ILogService LogService { get; set; }

        public SerilogMiddleware(RequestDelegate next, ILogService logService)
        {
            LogService = logService;

            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var sw = Stopwatch.StartNew();
            try
            {
                await _next(httpContext);
                sw.Stop();

                var statusCode = httpContext.Response?.StatusCode;
                var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                var log = level == LogEventLevel.Error ? LogForErrorContext(httpContext) : Log;
                log.Write(level, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, statusCode, sw.Elapsed.TotalMilliseconds);
            }
            // Never caught, because `LogException()` returns false.
            catch (Exception ex) when (LogException(httpContext, sw, ex)) { }
        }

        private bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
        {
            sw.Stop();

            var log = BuildLog(ex);
            LogService.Save(log);

            LogForErrorContext(httpContext)
                .Error(ex, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, 500, sw.Elapsed.TotalMilliseconds);

            return false;
        }

        private static ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var result = Log
                .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            if (request.HasFormContentType)
                result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

            return result;
        }

        private static Log BuildLog (Exception ex)
        {
            var trace = new StackTrace(ex, true);

            var log = new Log
            {
                Source = ex.Source,
                Message = ex.InnerException.Message,
                StackTrace = ex.StackTrace,
                Method = trace.GetFrames().FirstOrDefault()?.GetMethod().Name,
                Class = trace.GetFrames().FirstOrDefault(x => x.GetFileName() != null)?.GetFileName()
            };

            return log;
        }
    }
}
