using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.Models;

public class SubjectResource : BaseModel
{
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string Description { get; set; } = null!;

    public int Semester { get; set; } // Represents the semester in which the subject is taught.

    public List<Resource> Resources { get; set; } = new();
}