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
        public int? DeptartmentId { get; set; }
        public Department? Deptartment { get; set; }
        public ICollection<CrsResult>? CrsResults { get; set; }
    }
}
