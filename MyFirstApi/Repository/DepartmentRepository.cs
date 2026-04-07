using MyFirstApi.Data;
using MyFirstApi.Dtos;
using MyFirstApi.Repository;


namespace MyFirstApi.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<int> AddDepartmentAsync(DepartmentDto department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));
            var newDepartment = new Models.Department
            {
                Name = department.Name,
                Location = department.Location
            };
            _context.Departments.Add(newDepartment);
            _context.SaveChanges();
            return Task.FromResult(newDepartment.Id);
        }

    }
}
