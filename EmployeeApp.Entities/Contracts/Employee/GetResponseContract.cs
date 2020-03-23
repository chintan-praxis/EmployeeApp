using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Entities.Contracts.Employee
{
    public class GetResponseContract
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
