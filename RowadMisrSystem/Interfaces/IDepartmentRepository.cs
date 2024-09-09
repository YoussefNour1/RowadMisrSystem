using RowadMisrSystem.Models;

namespace RowadMisrSystem.Interfaces;
public interface IDepartmentRepository
{
    Task AddDepartmentAsync(Department department);
    Task<Department?> GetDepartmentByIdAsync(int id);
    Task<List<Department>> GetAllDepartmentsAsync();
    Task UpdateDepartmentAsync(Department department);
    Task DeleteDepartmentAsync(int id);
}