using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.WebAPI.Installers
{
    public class ApiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TweetBook API", Version = "v1" });

            //    var security = new Dictionary<string, IEnumerable<string>> {
            //                { "Bearer", new string[0] }
            //            };

            //    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            //    {
            //        Description = "JWT Authorization header using the bearer scheme",
            //        Name = "Authorization",
            //        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            //        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            //    });

            //    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
            //                { new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
            //                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
            //                        Id = "Bearer",
            //                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
            //                } }  ,new List<string>()} });
            //});

            services.AddControllers();
        }


    }
}
