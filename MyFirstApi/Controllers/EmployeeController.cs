using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Dtos;
using MyFirstApi.Repository;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly AppDbContext _dbcontext;
        public EmployeeController(AppDbContext dbcontext, IEmployeeRepository repository)
        {
            _dbcontext = dbcontext;
            _repository = repository;
        }
        [HttpPost]


        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeDto request)
        {
            if (request == null)
            {
                return BadRequest("employee data is required.");
            }
            var newEmployeeId = await _repository.AddEmployeeAsync(request);
            var createdEmplyee = await _dbcontext.Employees.Where(e => e.Id == newEmployeeId).Select(e => new EmployeeDto
            {
                //Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Description = e.Description,

            }).FirstOrDefaultAsync();

            return Created("", createdEmplyee);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int Id)
        {
            var employee = await _repository.GetEmployeeAsync(Id);
            if (employee == null)


            {
                return NotFound($"employee with {Id}  not found");
            }
            return Ok(employee);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int Id)
        {
            var success = await _repository.DeleteEmployeeAsync(Id);

            if (!success)
            {
                return NotFound($"employee with {Id} not found");

            }
            return NoContent();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateEmployee(int Id, [FromBody] EmployeeDto request)
        {

            var updated = await _repository.UpdateEmployeeAsync(Id, request);
            if (!updated)
            {
                return NotFound($"employee with {Id} not found ");
            }
            return Ok("employee updated successfully");

        }
    }
}

