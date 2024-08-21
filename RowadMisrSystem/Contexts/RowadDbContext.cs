using Microsoft.EntityFrameworkCore;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Contexts
{
    public class RowadDbContext: DbContext
    {
        public DbSet<Trainee> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<CrsResult> Instructors { get; set; }
        public DbSet<CrsResult> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LUCIFER\\MSSQLSERVER01; Database=RowadDB; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CrsResult>(E =>
            {
                E.HasOne(CR => CR.Trainee).WithMany(T=> T.CrsResults); 
                E.HasKey(CR => new { CR.TraineeId, CR.CourseId });
                E.HasOne(CR => CR.Course).WithMany(C => C.CrsResults);
            });
        }
    }
}
