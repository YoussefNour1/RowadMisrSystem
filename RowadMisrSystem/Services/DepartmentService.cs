using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Services
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _departmentRepository.UpdateDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }
    }
}
