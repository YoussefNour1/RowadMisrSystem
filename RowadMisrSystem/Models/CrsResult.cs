using System.ComponentModel.DataAnnotations.Schema;

namespace RowadMisrSystem.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class CrsResult
    {
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Grade Grade { get; set; }
        // Navigational property 
        public Trainee? Trainee { get; set; }
        public Course? Course { get; set; }
    }
}
