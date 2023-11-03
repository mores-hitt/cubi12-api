using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password")]
        public string RepeatedPassword { get; set; } = null!;
    }
}