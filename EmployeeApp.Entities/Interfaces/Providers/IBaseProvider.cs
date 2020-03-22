using EmployeeApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Entities.Interfaces.Providers
{
    public interface IBaseProvider<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(T obj);
        T Upsert(T obj);
        T Delete(T obj);
    }
}
