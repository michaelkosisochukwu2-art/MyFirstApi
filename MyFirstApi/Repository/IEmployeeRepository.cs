using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Dtos;

namespace MyFirstApi.Repository
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployeeAsync(EmployeeDto employee);

        Task<EmployeeDto> GetEmployeeAsync(int id);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> UpdateEmployeeAsync(int Id, EmployeeDto employee);

    }
}
