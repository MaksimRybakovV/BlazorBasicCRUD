using BlazorBasicCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBasicCRUD.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"DataSource={Environment.CurrentDirectory}/Data/DataBase/SimpleBlazorDB.db");
        }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
