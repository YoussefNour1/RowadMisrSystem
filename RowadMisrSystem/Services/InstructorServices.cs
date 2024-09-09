using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Models;
using System.Collections.Generic;

namespace RowadMisrSystem.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task AddInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.AddInstructorAsync(instructor);
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _instructorRepository.GetInstructorByIdAsync(id);
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorRepository.GetAllInstructorsAsync();
        }

        public async Task UpdateInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.UpdateInstructorAsync(instructor);
        }

        public async Task DeleteInstructorAsync(int id)
        {
            await _instructorRepository.DeleteInstructorAsync(id);
        }
    }
}
