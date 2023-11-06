using BlazorBasicCRUD.Server.Data;
using BlazorBasicCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBasicCRUD.Server.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> AddEmployeeAsync(Employee newEmployee)
        {
            var response = new ServiceResponse<int>();
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            var employee = _context.Employees
                    .Max(e => e.Id);
            response.Data = employee;
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteEmployeeAsync(int id)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var employee = await _context.Employees
                    .Include(e => e.Company)
                    .SingleOrDefaultAsync(e => e.Id == id)
                    ?? throw new Exception($"Employee with Id '{id}' not found!");

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                response.Data = $"Employee with Id '{id}' deleted!";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Employee>>> GetAllEmployeesAsync()
        {
            var response = new ServiceResponse<List<Employee>>();

            response.Data = await _context.Employees
                .Include(e => e.Company)
                .ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<Employee>> GetEmployeeByIdAsync(int id)
        {
            var response = new ServiceResponse<Employee>();

            try
            {
                var employee = await _context.Employees
                    .SingleOrDefaultAsync(e => e.Id == id)
                    ?? throw new Exception($"Employee with Id '{id}' not found!");

                response.Data = employee;
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> UpdateEmployeeAsync(Employee updatedEmployee)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var employee = await _context.Employees
                    .SingleOrDefaultAsync(e => e.Id == updatedEmployee.Id)
                    ?? throw new Exception($"Employee with Id '{updatedEmployee.Id}' not found!");

                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Age = updatedEmployee.Age;
                employee.JobTitle = updatedEmployee.JobTitle;
                employee.CompanyId = updatedEmployee.CompanyId;

                response.Data = $"Employee with Id '{updatedEmployee.Id}' updated!";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
