using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RowadMisrSystem.Models;

public class Trainee
{
    public int TraineeId { get; set; }
    [Required]
    public string? Name { get; set; }
    [AllowNull]
    public string? Image { get; set; }
    public string? Address { get; set; }
    public decimal Grade { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }  
    public ICollection<CrsResult>? CrsResults { get; set; } = new HashSet<CrsResult>();
}