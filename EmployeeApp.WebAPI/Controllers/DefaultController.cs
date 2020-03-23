using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Entities.Contracts.Employee;
using EmployeeApp.Entities.Interfaces.Providers;
using EmployeeApp.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static EmployeeApp.Entities.Models.APIRoute;

namespace EmployeeApp.WebAPI.Controllers
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IEmployeeProvider provider;

        public DefaultController(IEmployeeProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet(EmployeeRoutes.GetAll)]
        public IActionResult Index()
        {
            var getall = provider.GetAll().Select(S => new GetAllResponseContract { Id = S.Id, Name = S.Name }).ToList();
            return Ok(getall);
        }

        [HttpGet(EmployeeRoutes.Get)]
        public IActionResult Get([FromRoute] Guid employeeId)
        {
            var employee = provider.Get(new EmployeeModel { Id = employeeId });

            if (employee == null)
                return NotFound();

            return Ok(new GetResponseContract { Id = employee.Id, Name = employee.Name });
        }


        [HttpPut(EmployeeRoutes.Update)]
        public IActionResult Update([FromRoute] Guid employeeId, [FromBody] UpsertRequestContract request)
        {
            var employee = new EmployeeModel()
            {
                Id = employeeId,
                Name = request.Name
            };

            var updated = provider.Upsert(employee);
            if (updated.Id != Guid.Empty)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost(EmployeeRoutes.Create)]
        public IActionResult Create([FromBody] UpsertRequestContract request)
        {
            var employee = new EmployeeModel { Name = request.Name };

            var created = provider.Upsert(employee);
            if (created.Id != Guid.Empty)
                return Ok(created.Id);
            else
                return BadRequest();
        }

        [HttpDelete(EmployeeRoutes.Delete)]
        public IActionResult Delete([FromRoute] Guid employeeId)
        {
            var deleted = provider.Delete(new EmployeeModel { Id = employeeId });
            if (deleted.Id != Guid.Empty)
                return Ok();
            else
                return NotFound();
        }
    }
}