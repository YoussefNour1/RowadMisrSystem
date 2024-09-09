using RowadMisrSystem.Contexts;
using RowadMisrSystem.Models;
using Microsoft.EntityFrameworkCore;
using RowadMisrSystem.Interfaces;

namespace RowadMisrSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly RowadDbContext _context;
        public DepartmentRepository(RowadDbContext context)
        {
            _context = context;
        }

        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(D=> D.Id == id);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}