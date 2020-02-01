using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CubeGPS.Root;
using CubeGPS.Models.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CubeGPS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<APICredentialsConfig>(Configuration.GetSection("APICredentials"));
            services.Configure<LoggingConfig>(Configuration.GetSection("Logging"));

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            DIRoot.InjectDependencies(services, connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IOptions<LoggingConfig> _loggingConfig)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddFile(_loggingConfig.Value.PathFormat, _loggingConfig.Value.MinimumLevel, _loggingConfig.Value.Override, _loggingConfig.Value.IsJson, _loggingConfig.Value.FileSizeLimitBytes, _loggingConfig.Value.RetainedFileCountLimit);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CubeGPS}/{action=Index}/{id?}");
            });
        }
    }
}
