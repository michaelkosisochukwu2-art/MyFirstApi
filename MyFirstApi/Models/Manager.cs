namespace MyFirstApi.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public string Department { get; set; }
        public int NumberOfStaff { get; set; }
    }
}
