using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowadMisrSystem.Models
{
    public class Course
    {
        //
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<CrsResult>? CrsResults { get; set; }
    }
}
