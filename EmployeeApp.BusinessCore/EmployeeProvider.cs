using EmployeeApp.Entities.Interfaces.Providers;
using EmployeeApp.Entities.Interfaces.Repositories;
using EmployeeApp.Entities.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.BusinessCore
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository repository;
        public EmployeeProvider(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public Task<EmployeeModel> DeleteAsync(EmployeeModel obj)
        {
            return repository.DeleteAsync(obj);
        }

        public Task<EmployeeModel> GetAsync(EmployeeModel obj)
        {
            return repository.GetAsync(obj);
        }

        public Task<List<EmployeeModel>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<EmployeeModel> UpsertAsync(EmployeeModel obj)
        {
            return repository.UpsertAsync(obj);
        }
    }
}
