using RowadMisrSystem.Models;

namespace RowadMisrSystem.Interfaces
{
    public interface IInstructorRepository
    {
        Task AddInstructorAsync(Instructor instructor);
        Task<Instructor?> GetInstructorByIdAsync(int id);
        Task<List<Instructor>> GetAllInstructorsAsync();
        Task UpdateInstructorAsync(Instructor instructor);
        Task DeleteInstructorAsync(int id);
    }
}
