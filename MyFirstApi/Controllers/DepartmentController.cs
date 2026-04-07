using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Dtos;
using MyFirstApi.Repository;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
 
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository= departmentRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddDepartment([FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null) return BadRequest();
            var newId = await _departmentRepository.AddDepartmentAsync(departmentDto);
            return CreatedAtAction(nameof(AddDepartment), new { id = newId }, newId);
        }
    }
}
