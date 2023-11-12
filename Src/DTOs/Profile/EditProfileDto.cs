using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.DTOs.Profile
{
    public class EditProfileDto
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
    }
}