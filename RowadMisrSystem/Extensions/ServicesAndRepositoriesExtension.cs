using RowadMisrSystem.Contexts;
using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Repositories;
using RowadMisrSystem.Services;

namespace RowadMisrSystem.Extensions
{
    public static class ServicesAndRepositoriesExtension
    {
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection Services)
        {
            // Add services to the container.
            Services.AddScoped<IDepartmentService, DepartmentService>();
            Services.AddScoped<IInstructorService, InstructorService>();

            // Add Repos to the container
            Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            Services.AddScoped<IInstructorRepository, InstructorRepository>();
            return Services;
        }

    }
}
