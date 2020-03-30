using EmployeeApp.EFCore.DatabaseContext;
using EmployeeApp.EFCore.DbModels;
using EmployeeApp.Entities.Interfaces.Repositories;
using EmployeeApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.EFCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EmployeeModel> DeleteAsync(EmployeeModel obj)
        {
            EmployeeModel model = new EmployeeModel();
            var item = dbContext.Tb_Employees.Where(W => W.Id == obj.Id).FirstOrDefault();
            if (item != null)
            {
                model.Id = item.Id;
                dbContext.Tb_Employees.Remove(item);
                await dbContext.SaveChangesAsync();
            }
            return model;
        }

        public async Task<EmployeeModel> GetAsync(EmployeeModel obj)
        {
            EmployeeModel model = await dbContext.Tb_Employees.Where(W => W.Id == obj.Id).Select(S => new EmployeeModel
            {
                Id = S.Id,
                Name = S.Name
            }).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await dbContext.Tb_Employees.Select(S => new EmployeeModel { Id = S.Id, Name = S.Name }).ToListAsync();
        }

        public async Task<EmployeeModel> UpsertAsync(EmployeeModel obj)
        {
            EmployeeModel model = new EmployeeModel();
            if (obj.Id == Guid.Empty)
            {
                // Insert
                tb_employee employee = new tb_employee();
                employee.Id = Guid.NewGuid();
                employee.Name = obj.Name;
                await dbContext.Tb_Employees.AddAsync(employee);
            }
            else
            {
                // Update
                model.Id = obj.Id;
                tb_employee employee = await dbContext.Tb_Employees.Where(W => W.Id == obj.Id).FirstOrDefaultAsync();
                if (employee != null)
                {
                    employee.Name = obj.Name;
                }
            }

            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}
