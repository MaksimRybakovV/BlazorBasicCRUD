using BlazorBasicCRUD.Shared.Models;

namespace BlazorBasicCRUD.Client.Services.HttpService
{
    public interface IHttpService
    {
        public List<Employee> Employees { get; set; }
        public List<Company> Companies { get; set; }
        public Task GetEmployees();
        public Task GetCompanies();
    }
}
