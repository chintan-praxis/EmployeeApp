using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.MVC.Installers
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration Configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(w => typeof(IInstaller).IsAssignableFrom(w) && w.IsClass).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(options => options.InstallServices(services, Configuration));
        }
    }
}
