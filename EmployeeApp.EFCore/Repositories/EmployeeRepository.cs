using EmployeeApp.EFCore.DatabaseContext;
using EmployeeApp.EFCore.DbModels;
using EmployeeApp.Entities.Interfaces.Repositories;
using EmployeeApp.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeApp.EFCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EmployeeModel Delete(EmployeeModel obj)
        {
            EmployeeModel model = new EmployeeModel();
            var item = dbContext.Tb_Employees.Where(W => W.Id == obj.Id).FirstOrDefault();
            if (item != null)
            {
                model.Id = item.Id;
                dbContext.Tb_Employees.Remove(item);
                dbContext.SaveChanges();
            }
            return model;
        }

        public EmployeeModel Get(EmployeeModel obj)
        {
            EmployeeModel model = dbContext.Tb_Employees.Where(W => W.Id == obj.Id).Select(S => new EmployeeModel
            {
                Id = S.Id,
                Name = S.Name
            }).FirstOrDefault();

            return model;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            return dbContext.Tb_Employees.Select(S => new EmployeeModel { Id = S.Id, Name = S.Name }).AsEnumerable();
        }

        public EmployeeModel Upsert(EmployeeModel obj)
        {
            EmployeeModel model = new EmployeeModel();
            if (obj.Id == Guid.Empty)
            {
                // Insert
                tb_employee employee = new tb_employee();
                employee.Id = Guid.NewGuid();
                employee.Name = obj.Name;
                dbContext.Tb_Employees.Add(employee);
            }
            else
            {
                // Update
                model.Id = obj.Id;
                tb_employee employee = dbContext.Tb_Employees.Where(W => W.Id == obj.Id).FirstOrDefault();
                if(employee != null)
                {
                    employee.Name = obj.Name;
                }
            }

            dbContext.SaveChanges();
            return model;
        }
    }
}
