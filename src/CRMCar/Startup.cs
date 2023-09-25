using Microsoft.OpenApi.Models;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CRMCar.Repository;
using CRMCar.Extensions;
using static CRMCar.Extensions.ApiKeyAuthorizationFilter;
using CRMCar.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DocnetCorePractice
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(WebApplicationBuilder builder, IWebHostEnvironment env)
        {
            _configuration = builder.Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMCar.API", Version = "v1" });
            });

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = false;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = false;
            });

            var connectionString = _configuration.GetConnectionString("DefaultConnectStrings");
            AddDI(services);
            //add
            services.AddSingleton<ApiKeyAuthorizationFilter>();
            services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

            services.AddAuthentication("Bearer").AddJwtBearer(_ =>
            {
                _.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gj6ghgowrhg949gjgofksnk3frmkf")),
                };
            });

        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var isUserSwagger = _configuration.GetValue<bool>("UseSwagger", false);
            if (isUserSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRMCar v1");
                });
            }

            //app.UseMiddleware<ApiKeyAuthenExtension>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.MapControllers();

            //app.UseRouting();
            //    app.UseEndpoints(endpoint =>
            //    {
            //        endpoint.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            //    });
        }

        private void AddDI(IServiceCollection services)
        {
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
