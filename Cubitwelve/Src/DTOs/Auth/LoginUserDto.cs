using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.Auth.DTOs
{
    public class LoginUserDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}