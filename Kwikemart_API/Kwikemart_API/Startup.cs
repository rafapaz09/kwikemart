using System.IO;
using System.Text;
using Kwikemart_API.Helpers;
using Kwikemart_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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


            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            
            //JWT AUTHENTICATION KEY GENERATOR
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true
               };
           });

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new Info { Title = apiName, Version = version });
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
                c.SwaggerEndpoint("/docs/v1/docs.json", "KwikEMart API");
            });

            app.UseAuthentication();
            app.UseMvc();
        }

    }
}
