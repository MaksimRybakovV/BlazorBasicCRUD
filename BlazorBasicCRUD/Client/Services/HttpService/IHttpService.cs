using BlazorBasicCRUD.Shared.Models;

namespace BlazorBasicCRUD.Client.Services.HttpService
{
    public interface IHttpService
    {
        public List<Employee> Employees { get; set; }
        public List<Company> Companies { get; set; }
        public Task GetEmployees();
        public Task<PageServiceResponse<List<Employee>>> GetPageEmployees(int page, int pageSize);
        public Task<ServiceResponse<Employee>> GetEmployee(int id);
        public Task AddEmployee(Employee newEmployee);
        public Task UpdateEmployee(Employee updatedEmployee);
        public Task DeleteEmployee(int id);
        public Task GetCompanies();
        public Task<ServiceResponse<Company>> GetCompany(int id);
        public Task AddCompany(Company newCompany);
        public Task UpdateCompany(Company updatedCompany);
        public Task DeleteCompany(int id);
    }
}
