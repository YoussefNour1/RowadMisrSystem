using RowadMisrSystem.Models;

namespace RowadMisrSystem.Interfaces
{
    public interface IInstructorService
    {
        Task AddInstructorAsync(Instructor instructor);
        Task<Instructor?> GetInstructorByIdAsync(int id);
        Task<List<Instructor>> GetAllInstructorsAsync();
        Task UpdateInstructorAsync(Instructor instructor);
        Task DeleteInstructorAsync(int id);
    }
}
