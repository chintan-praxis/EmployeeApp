using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Entities.Contracts.Employee
{
    public class GetAllResponseContract
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
