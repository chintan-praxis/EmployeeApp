using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Common;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.MVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly ConfigUI configUI;

        public BaseController(ConfigUI configUI)
        {
            this.configUI = configUI;
            AssignConfig();
        }

        private void AssignConfig()
        {
            AppKeys.Client = configUI.EmployeeAppAPI.Client;
        }
    }
}