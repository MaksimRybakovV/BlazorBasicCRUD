using BlazorBasicCRUD.Server.Data;
using BlazorBasicCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBasicCRUD.Server.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;

        public CompanyService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> AddCompanyAsync(Company newCompany)
        {
            var response = new ServiceResponse<int>();
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();
            var company = _context.Companies
                    .Max(c => c.Id);
            response.Data = company;
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteCompanyAsync(int id)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var company = await _context.Companies
                    .SingleOrDefaultAsync(c => c.Id == id)
                    ?? throw new Exception($"Company with Id '{id}' not found!");

                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                response.Data = $"Company with Id '{id}' deleted!";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Company>>> GetAllCompaniesAsync()
        {
            var response = new ServiceResponse<List<Company>>();

            response.Data = await _context.Companies
                .ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<Company>> GetCompanyByIdAsync(int id)
        {
            var response = new ServiceResponse<Company>();

            try
            {
                var company = await _context.Companies
                    .SingleOrDefaultAsync(c => c.Id == id)
                    ?? throw new Exception($"Company with Id '{id}' not found!");

                response.Data = company;
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> UpdateCompanyAsync(Company updatedCompany)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var company = await _context.Companies
                    .SingleOrDefaultAsync(c => c.Id == updatedCompany.Id)
                    ?? throw new Exception($"Company with Id '{updatedCompany.Id}' not found!");

                company.Name = updatedCompany.Name;

                await _context.SaveChangesAsync();
                response.Data = $"Company with Id '{updatedCompany.Id}' updated!";
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
