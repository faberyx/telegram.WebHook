using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Serilog;
using Serilog.Sinks.RollingFile;
using Serilog.Events;
using System.IO;

namespace telegram.webHook
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.RollingFile(
                   Path.Combine(env.WebRootPath, "log-{Date}.txt"),
                   LogEventLevel.Debug)
               .WriteTo.LiterateConsole(LogEventLevel.Information)
               .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.Configure<Classes.BotSettings>(Configuration.GetSection("BotSettings"));

         

            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<Models.Context.SQLiteContext>(
                options => { options.UseSqlite($"Data Source=Files/DB/data.db"); });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            loggerFactory.AddDebug();
            app.UseIISPlatformHandler();
              
            app.UseMvc();
             
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
