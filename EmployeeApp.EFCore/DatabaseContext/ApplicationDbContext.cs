using EmployeeApp.EFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.EFCore.DatabaseContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option): base(option)
        {
            
        }

        public DbSet<tb_employee> Tb_Employees { get; set; }
    }
}
