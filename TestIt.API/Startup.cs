using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;
using TestIt.API.Diagnostics;
using TestIt.API.ViewModels.Mappings;
using TestIt.Business;
using TestIt.Business.Services;
using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Utils.Email;

namespace TestIt.API
{
    public partial class Startup
    {
        private IConfigurationRoot Configuration { get; }
        private static string _applicationPath = string.Empty;
        private bool IsProd { get; set; }
        string _sqlConnectionString = string.Empty;
        bool _useInMemoryProvider;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            IsProd = env.IsProduction();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            Log.Information("Starting up");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                _useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
            }
            catch
            {
                // ignored
            }

            services.AddDbContext<TestItContext>(options => {
                switch (_useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase();
                        break;
                    default:
                        options.UseSqlServer(sqlConnectionString,
                    b => b.MigrationsAssembly("TestIt.API"));
                        break;
                }
            });

            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassStudentsRepository, ClassStudentsRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IEssayQuestionRepository, EssayQuestionRepository>();
            services.AddScoped<IAlternativeQuestionRepository, AlternativeQuestionRepository>();
            services.AddScoped<IAlternativeRepository, AlternativeRepository>();
            services.AddScoped<IClassTestsRepository, ClassTestsRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IAnsweredQuestionRepository, AnsweredQuestionRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassStudentsService, ClassStudentsService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IExamService, ExamService>();
            AutoMapperConfiguration.Configure();

            services.AddCors();

            services.AddMvc()
                .AddJsonOptions(opts =>
                {
                    // Force Camel Case to JSON
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddSingleton<IConfiguration>(Configuration);

        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            ConfigureAuth(app);
            
            app.UseExceptionHandler(
              builder =>
              {
                  builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        { 
                            await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                        }
                    });
              });

            if (IsProd)
                app.UseMiddleware<SerilogMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            TestItDbInitializer.Initialize(app.ApplicationServices);
        }
    }
}
