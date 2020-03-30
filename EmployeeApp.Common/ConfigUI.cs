using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Common
{
    public class ConfigUI
    {
        public EmployeeAppAPI EmployeeAppAPI { get; set; } = new EmployeeAppAPI();
    }

    public class EmployeeAppAPI
    {
        public string Client { get; set; }
        public string BaseAddress { get; set; }
    }
}
