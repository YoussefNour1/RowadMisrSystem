using Microsoft.EntityFrameworkCore;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Contexts
{
    public class RowadDbContext : DbContext
    {
        public DbSet<Trainee> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }

        public RowadDbContext(DbContextOptions<RowadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CrsResult>(E =>
            {
                E.HasOne(CR => CR.Trainee).WithMany(T => T.CrsResults).OnDelete(DeleteBehavior.Restrict);
                E.HasKey(CR => new { CR.TraineeId, CR.CourseId });
                E.HasOne(CR => CR.Course).WithMany(C => C.CrsResults).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Instructor>()
                        .HasOne(i => i.Department)
                        .WithMany(d => d.Instructors)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                        .HasOne(c => c.Department)
                        .WithMany(d => d.Courses)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainee>()
                        .HasOne(t => t.Department)
                        .WithMany(d => d.Trainees)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
