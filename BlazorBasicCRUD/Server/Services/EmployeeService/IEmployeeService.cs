using BlazorBasicCRUD.Shared.Models;

namespace BlazorBasicCRUD.Server.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<ServiceResponse<List<Employee>>> GetAllEmployeesAsync();
        public Task<ServiceResponse<Employee>> GetEmployeeByIdAsync(int id);
        public Task<PageServiceResponse<List<Employee>>> GetEmployeesByPageAsync(int page, int pageSize);
        public Task<ServiceResponse<int>> AddEmployeeAsync(Employee newEmployee);
        public Task<ServiceResponse<string>> UpdateEmployeeAsync(Employee updatedEmployee);
        public Task<ServiceResponse<string>> DeleteEmployeeAsync(int id);
    }
}
