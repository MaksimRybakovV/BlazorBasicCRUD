using BlazorBasicCRUD.Server.Services.CompanyService;
using BlazorBasicCRUD.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBasicCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Company>>>> GetAll()
        {
            return await _service.GetAllCompaniesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Company>>> GetSingle(int id)
        {
            var response = await _service.GetCompanyByIdAsync(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> PostCompany(Company newCompany)
        {
            var response = await _service.AddCompanyAsync(newCompany);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateCompany(Company updatedCompany)
        {
            var response = await _service.UpdateCompanyAsync(updatedCompany);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteCompany(int id)
        {
            var response = await _service.DeleteCompanyAsync(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
