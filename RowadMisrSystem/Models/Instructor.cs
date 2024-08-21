using System.ComponentModel.DataAnnotations;

namespace RowadMisrSystem.Models
{

    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }

        public Department? Department { get; set; }

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();


    }
}
