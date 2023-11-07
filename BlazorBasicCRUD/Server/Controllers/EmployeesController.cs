using BlazorBasicCRUD.Server.Services.EmployeeService;
using BlazorBasicCRUD.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBasicCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Employee>>>> GetAll()
        {
            return await _service.GetAllEmployeesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Employee>>> GetSingle(int id)
        {
            var response = await _service.GetEmployeeByIdAsync(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> PostEmployee(Employee newEmployee)
        {
            var response = await _service.AddEmployeeAsync(newEmployee);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateEmployee(Employee updatedEmployee)
        {
            var response = await _service.UpdateEmployeeAsync(updatedEmployee);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteEmployee(int id)
        {
            var response = await _service.DeleteEmployeeAsync(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
