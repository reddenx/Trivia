using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TriviaApi.AppStart;

namespace TriviaApi
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
            //general universal preferences I have for apps
            services.AddHttpContextAccessor();
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            //auth
            DependencyConfiguration.RegisterAuthDependencies(services, Configuration);

            //application dependencies
            DependencyConfiguration.RegisterApplicationDependencies(services, Configuration);

            //register the controllers as dependencies
            services.AddControllers();

            //register swagger dependencies
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //shows full stacktrace on exception
                app.UseDeveloperExceptionPage();

                //sets up a VERY loose cors policy while developing, mainly for enabling live editing using a different front end proxy server
                app.UseCors(config =>
                    config.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(Configuration.GetValue<string>("frontEndProxyServer"))
                        .AllowCredentials());

                //enables test endpoint for api development
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "trivia api v1");
                });
            }

            //enables general http routing in aspnet
            app.UseRouting();

            //enables authorization based on routes
            app.UseAuthentication();
            app.UseAuthorization();

            //enables controllers to receive http routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
