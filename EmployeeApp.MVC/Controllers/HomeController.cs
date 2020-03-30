using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeApp.MVC.Models;
using System.Net.Http;
using EmployeeApp.Common;

namespace EmployeeApp.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory, ConfigUI configUI) : base (configUI)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var client = httpClientFactory.CreateClient("");
            var result = client.GetStringAsync("/");
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
