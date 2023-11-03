using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Auth
{
    public class RegisterStudentDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstLastName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string SecondLastName { get; set; } = null!;

        [Required]
        public string RUT { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public int CareerId { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 10)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).+$")]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string RepeatedPassword { get; set; } = null!;
    }
}