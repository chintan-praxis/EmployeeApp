using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Entities.Models
{
    public class APIRoute
    {
        public const string Root = "api";
        public static class EmployeeRoutes
        {
            public const string GetAll = Root + "/employee";
            public const string Create = Root + "/employee";
            public const string Get = Root + "/employee/{employeeId}";
            public const string Update = Root + "/employee/{employeeId}";
            public const string Delete = Root + "/employee/{employeeId}";
        }
    }
}
