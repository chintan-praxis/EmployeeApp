using EmployeeApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Entities.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(T obj);
        Task<T> UpsertAsync(T obj);
        Task<T> DeleteAsync(T obj);
    }
}
