using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Entities.Interfaces.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IEmployeeProvider provider;

        public DefaultController(IEmployeeProvider provider)
        {
            this.provider = provider;
        }

        public IActionResult Index()
        {
            return Ok(provider.GetAll());
        }
    }
}