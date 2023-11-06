using BlazorBasicCRUD.Shared.Models;
using System.Net.Http.Json;

namespace BlazorBasicCRUD.Client.Services.HttpService
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Company> Companies { get; set; } = new List<Company>();

        public HttpService(HttpClient client)
        {
            _client = client;
        }

        public async Task GetEmployees()
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<List<Employee>>>("api/employees");
            if (response?.IsSuccessful == true)
                Employees = response.Data;
        }

        public async Task GetCompanies()
        {
            var response = await _client.GetFromJsonAsync<ServiceResponse<List<Company>>>("api/companies");
            if (response?.IsSuccessful == true)
                Companies = response.Data;
        }
    }
}
