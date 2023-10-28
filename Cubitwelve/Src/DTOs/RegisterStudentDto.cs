using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs
{
    public class RegisterStudentDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string FirstLastName { get; set; } = null!;

        [Required]
        public string SecondLastName { get; set; } = null!;

        [Required]
        public string RUT { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Career { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}