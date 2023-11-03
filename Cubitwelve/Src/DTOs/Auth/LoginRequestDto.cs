using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(10, ErrorMessage = "Invalid Credentials")]
        public string Password { get; set; } = null!;

        [Required]
        [MinLength(10, ErrorMessage = "Invalid Credentials")]
        [Compare("Password")]
        public string RepeatedPassword { get; set; } = null!;
    }
}