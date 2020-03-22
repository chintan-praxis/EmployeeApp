using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Entities.Contracts
{
    public class EmployeeContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
