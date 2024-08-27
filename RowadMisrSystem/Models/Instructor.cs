﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowadMisrSystem.Models
{

    public class Instructor
    {
        public int InstructorId { get; set; }
        [Required]
        [DisplayName("Instructor Name")]
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
