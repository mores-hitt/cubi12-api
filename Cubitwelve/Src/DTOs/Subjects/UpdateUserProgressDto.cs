using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Subjects
{
    public class UpdateUserProgressDto
    {
        // [RegularExpression(@"^[A-Za-z]{3}-\d{3}$", ErrorMessage = "Invalid format. It should be LLL-NNN.")]
        public List<string> AddSubjects { get; set; } = new();

        // [RegularExpression(@"^[A-Za-z]{3}-\d{3}$", ErrorMessage = "Invalid format. It should be LLL-NNN.")]
        public List<string> DeleteSubjects { get; set; } = new();
    }
}