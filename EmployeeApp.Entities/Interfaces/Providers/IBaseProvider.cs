using EmployeeApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Entities.Interfaces.Providers
{
    public interface IBaseProvider<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(T obj);
        Task<T> UpsertAsync(T obj);
        Task<T> DeleteAsync(T obj);
    }
}
