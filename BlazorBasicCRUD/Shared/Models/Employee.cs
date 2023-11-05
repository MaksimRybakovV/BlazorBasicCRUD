using BlazorBasicCRUD.Shared.Enums;

namespace BlazorBasicCRUD.Shared.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public JobTitle JobTitle { get; set; }

        public Company? Company { get; set; }
        public int CompanyId { get; set; }
    }
}
