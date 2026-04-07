using MyFirstApi.Dtos;

namespace MyFirstApi.Repository
{
    public interface IDepartmentRepository
    {
       
        Task<int> AddDepartmentAsync(DepartmentDto department);
    }
}
