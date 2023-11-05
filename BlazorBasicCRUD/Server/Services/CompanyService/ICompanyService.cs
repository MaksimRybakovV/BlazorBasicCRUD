using BlazorBasicCRUD.Shared.Models;

namespace BlazorBasicCRUD.Server.Services.CompanyService
{
    public interface ICompanyService
    {
        public Task<ServiceResponse<List<Company>>> GetAllCompaniesAsync();
        public Task<ServiceResponse<Company>> GetCompanyByIdAsync(int id);
        public Task<ServiceResponse<int>> AddCompanyAsync(Company newCompany);
        public Task<ServiceResponse<string>> UpdateCompanyAsync(Company updatedCompany);
        public Task<ServiceResponse<string>> DeleteCompanyAsync(int id);
    }
}
