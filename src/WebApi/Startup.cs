using AspNetCoreRateLimit;
using AutoMapper;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure.Configs;
using WebApi.Infrastructure.Extensions;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register services in Installers folder
            services.AddServicesInAssembly(Configuration);

            services.AddControllers()
                    .AddNewtonsoftJson(ops => { ops.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; })
                    .AddFluentValidation(fv => { fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false; });

            //Register Automapper
            services.AddAutoMapper(typeof(MappingProfileConfiguration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Enable Swagger and SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiTemplate ASP.NET Core API v1");
            });

            //Enable HealthChecks and UI
            app.UseHealthChecks("/selfcheck", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).UseHealthChecksUI(setup =>
            {
                setup.AddCustomStylesheet($"{env.ContentRootPath}/Infrastructure/HealthChecks/Ux/branding.css");
            });

            //Enable AspNetCoreRateLimit
            app.UseIpRateLimiting();

            app.UseRouting();

            //Enable CORS
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
