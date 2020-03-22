using EmployeeApp.Entities.Interfaces.Providers;
using EmployeeApp.Entities.Interfaces.Repositories;
using EmployeeApp.Entities.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace EmployeeApp.BusinessCore
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository repository;
        public EmployeeProvider(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public EmployeeModel Delete(EmployeeModel obj)
        {
            return repository.Delete(obj);
        }

        public EmployeeModel Get(EmployeeModel obj)
        {
            return repository.Get(obj);
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            return repository.GetAll();
        }

        public EmployeeModel Upsert(EmployeeModel obj)
        {
            return repository.Upsert(obj);
        }
    }
}
