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
        public async Task<IActionResult> Index()
        {
            var getallTask = await provider.GetAllAsync();
            return Ok(getallTask.Select(S => new GetAllResponseContract { Id = S.Id, Name = S.Name }).ToList());
        }

        [HttpGet(EmployeeRoutes.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid employeeId)
        {
            var employee = await provider.GetAsync(new EmployeeModel { Id = employeeId });

            if (employee == null)
                return NotFound();

            return Ok(new GetResponseContract { Id = employee.Id, Name = employee.Name });
        }


        [HttpPut(EmployeeRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid employeeId, [FromBody] UpsertRequestContract request)
        {
            var employee = new EmployeeModel()
            {
                Id = employeeId,
                Name = request.Name
            };

            var updated = await provider.UpsertAsync(employee);
            if (updated.Id != Guid.Empty)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost(EmployeeRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] UpsertRequestContract request)
        {
            var employee = new EmployeeModel { Name = request.Name };

            var created = await provider.UpsertAsync(employee);
            if (created.Id != Guid.Empty)
                return Ok(created.Id);
            else
                return BadRequest();
        }

        [HttpDelete(EmployeeRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid employeeId)
        {
            var deleted = await provider.DeleteAsync(new EmployeeModel { Id = employeeId });
            if (deleted.Id != Guid.Empty)
                return Ok();
            else
                return NotFound();
        }
    }
}