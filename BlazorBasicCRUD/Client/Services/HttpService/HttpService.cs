using BlazorBasicCRUD.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorBasicCRUD.Client.Services.HttpService
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        private readonly NavigationManager _navigation;

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Company> Companies { get; set; } = new List<Company>();

        public HttpService(HttpClient client, NavigationManager navigation)
        {
            _client = client;
            _navigation = navigation;
        }

        public async Task GetEmployees()
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<List<Employee>>>("api/employees");
            if (response?.IsSuccessful == true)
                Employees = response.Data;
        }

        public async Task<PageServiceResponse<List<Employee>>> GetPageEmployees(int page, int pageSize)
        {
            var response = await _client.GetFromJsonAsync<PageServiceResponse<List<Employee>>>($"api/employees/pagination?page={page}&pageSize={pageSize}");
            if (response?.IsSuccessful == true)
                Employees = response.Data;
            return response!;
        }

        public async Task<ServiceResponse<Employee>> GetEmployee(int id)
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<Employee>>($"api/employees/{id}");
            return response!;
        }

        public async Task AddEmployee(Employee newEmployee)
        {
            await _client.PostAsJsonAsync("api/employees", newEmployee);
            _navigation.NavigateTo("employees");
        }

        public async Task UpdateEmployee(Employee updatedEmployee)
        {
            await _client.PutAsJsonAsync($"api/employees/{updatedEmployee.Id}", updatedEmployee);
            _navigation.NavigateTo("employees");
        }

        public async Task DeleteEmployee(int id)
        {
            await _client.DeleteAsync($"api/employees/{id}");
            _navigation.NavigateTo("employees");
        }

        public async Task GetCompanies()
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<List<Company>>>("api/companies");
            if (response?.IsSuccessful == true)
                Companies = response.Data;
        }

        public async Task<ServiceResponse<Company>> GetCompany(int id)
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<Company>>($"api/companies/{id}");
            return response!;
        }

        public async Task AddCompany(Company newCompany)
        {
            await _client.PostAsJsonAsync("api/companies", newCompany);
            _navigation.NavigateTo("companies");
        }

        public async Task UpdateCompany(Company updatedCompany)
        {
            await _client.PutAsJsonAsync($"api/companies/{updatedCompany.Id}", updatedCompany);
            _navigation.NavigateTo("companies");
        }

        public async Task DeleteCompany(int id)
        {
            await _client.DeleteAsync($"api/companies/{id}");
            _navigation.NavigateTo("companies");
        }
    }
}
