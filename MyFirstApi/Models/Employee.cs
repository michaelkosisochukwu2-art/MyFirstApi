namespace MyFirstApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Department? Department { get;  set; } 
        public int? DepartmentId { get; set; }
    }
}
