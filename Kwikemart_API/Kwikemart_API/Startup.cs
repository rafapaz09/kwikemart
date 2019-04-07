using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kwikemart_API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Kwikemart_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public IHostingEnvironment env { get; set; }

        public Startup(IConfiguration configuration,IHostingEnvironment Env)
        {
            Configuration = configuration;
            env = Env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            string apiName = Configuration["ApiName"].ToString();
            string version = Configuration["ApiVersion"].ToString();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new Info { Title = apiName, Version = version });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ActionFilter));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/docs.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/v1/docs.json", "My API v1");
            });

            app.UseMvc();
        }

    }
}
