using Microsoft.EntityFrameworkCore;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly RowadDbContext _context;

        public InstructorRepository(RowadDbContext context)
        {
            _context = context;
        }

        public async Task AddInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors
                .Include(i => i.Courses)
                .Include(i => i.Department)
                .FirstOrDefaultAsync(i => i.InstructorId == id);
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _context.Instructors
                .Include(i => i.Courses)
                .Include(i => i.Department)
                .ToListAsync();
        }

        public async Task UpdateInstructorAsync(Instructor instructor)
        {
            var ins = _context.Instructors.AsNoTracking().First(I => I.InstructorId == instructor.InstructorId);
            instructor.Image = instructor.Image ?? ins.Image;
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInstructorAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
