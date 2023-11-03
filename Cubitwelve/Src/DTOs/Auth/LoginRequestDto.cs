using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(10)]
        public string Password { get; set; } = null!;

        [Required]
        [MinLength(10)]
        [Compare("Password")]
        public string RepeatedPassword { get; set; } = null!;
    }
}