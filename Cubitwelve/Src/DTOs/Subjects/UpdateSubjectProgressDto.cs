using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Subjects
{
    public class UpdateSubjectProgressDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SubjectId { get; set; }

        [Required]
        public bool IsAdded { get; set; } = false;
    }
}