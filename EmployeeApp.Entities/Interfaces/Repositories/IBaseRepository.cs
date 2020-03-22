using EmployeeApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Entities.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(T obj);
        T Upsert(T obj);
        T Delete(T obj);
    }
}
