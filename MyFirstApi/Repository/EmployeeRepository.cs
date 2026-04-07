using MyFirstApi.Data;
using MyFirstApi.Dtos;
using MyFirstApi.Models;
namespace MyFirstApi.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployeeAsync(EmployeeDto employee)
        {
            if (employee == null)  throw new ArgumentNullException(nameof(employee));

            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Id = employee.Id,
                Description = employee.Description,

            };
            await _context.Employees.AddAsync(newEmployee); ;
            await _context.SaveChangesAsync();
            return newEmployee.Id;
        }
        public async Task<EmployeeDto> GetEmployeeAsync(int Id)
        {
            var employee= await _context.Employees.FindAsync(Id);
            if (employee == null) return null; return new EmployeeDto()
            {
                Id = employee.Id,

                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Description = employee.Description
            };
        }
        public async Task<bool> DeleteEmployeeAsync(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null) return false;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateEmployeeAsync(int Id, EmployeeDto employee)
        {
           

            var existingEmployee = await _context.Employees.FindAsync(Id);
            if (existingEmployee == null) return false;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Description = employee.Description;
           
         
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
//Add Employee to the data base