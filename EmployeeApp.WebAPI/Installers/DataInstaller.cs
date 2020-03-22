using EmployeeApp.BusinessCore;
using EmployeeApp.EFCore.DatabaseContext;
using EmployeeApp.EFCore.Repositories;
using EmployeeApp.Entities.Interfaces.Providers;
using EmployeeApp.Entities.Interfaces.Repositories;
using EmployeeApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.WebAPI.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EFCoreConnection"));
            });

            #region Providers

            services.AddScoped<IEmployeeProvider, EmployeeProvider>();

            #endregion

            #region Repositories

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            #endregion
        }

    }
}
