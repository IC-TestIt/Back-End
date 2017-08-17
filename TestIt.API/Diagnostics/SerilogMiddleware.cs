﻿using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestIt.Business;

namespace TestIt.API.Diagnostics
{
    public class SerilogMiddleware
    {
        const string MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        static readonly ILogger Log = Serilog.Log.ForContext<SerilogMiddleware>();

        readonly RequestDelegate _next;

        private ILogService logService { get; set; }

        public SerilogMiddleware(RequestDelegate next, ILogService logService)
        {
            this.logService = logService;

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
            catch (Exception ex)
            {
                var log = BuildLog(ex);
                logService.Save(log);
            }
        }

        //static bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
        //{
        //    sw.Stop();

        //    LogForErrorContext(httpContext)
        //        .Error(ex, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, 500, sw.Elapsed.TotalMilliseconds);

        //    return false;
        //}

        static ILogger LogForErrorContext(HttpContext httpContext)
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

        static Model.Entities.Log BuildLog (Exception ex)
        {
            StackTrace trace = new StackTrace(ex, true);

            var log = new Model.Entities.Log()
            {
                Source = ex.Source,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Method = trace.GetFrames().FirstOrDefault().GetMethod().Name,
                Class = trace.GetFrames().FirstOrDefault().GetFileName()
            };

            return log;
        }
    }
}
