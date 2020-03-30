using EmployeeApp.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.MVC.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllersWithViews();

            var config = new ConfigUI();
            Configuration.Bind("ConfigUI", config);
            services.AddSingleton(config);

            services.AddHttpClient("", client =>
            {
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Add("Accept", "application/type-json");
            }).AddTransientHttpErrorPolicy(option => option.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
        }
    }
}
