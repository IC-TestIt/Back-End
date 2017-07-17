using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestIt.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TestIt.API.ViewModels.Mappings;

namespace TestIt.API
{
    public partial class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private static string _applicationPath = string.Empty;
        string sqlConnectionString = string.Empty;
        bool useInMemoryProvider = false;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
            }
            catch { }

            services.AddDbContext<TestItContext>(options => {
                switch (useInMemoryProvider)
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

            services.AddScoped<Data.Abstract.IClassRepository, Data.Repositories.ClassRepository>();
            services.AddScoped<Data.Abstract.IOrganizationRepository, Data.Repositories.OrganizationRepository>();
            services.AddScoped<Data.Abstract.ISocialIdRepository, Data.Repositories.SocialIdRepository>();
            services.AddScoped<Data.Abstract.IStudentRepository, Data.Repositories.StudentRepository>();
            services.AddScoped<Data.Abstract.ITeacherRepository, Data.Repositories.TeacherRepository>();
            services.AddScoped<Data.Abstract.IUserRepository, Data.Repositories.UserRepository>();

            services.AddScoped<Business.IUserService, Business.Services.UserService>();
            services.AddScoped<Business.ITeacherService, Business.Services.TeacherService>();

            AutoMapperConfiguration.Configure();

            services.AddCors();

            services.AddMvc()
                .AddJsonOptions(opts =>
                {
                    // Force Camel Case to JSON
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

        }

        public void Configure(IApplicationBuilder app)
        {
            ConfigureAuth(app);

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

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
