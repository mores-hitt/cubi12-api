namespace Cubitwelve.Src.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; } = null!;

        public string FirstLastName { get; set; } = null!;

        public string SecondLastName { get; set; } = null!;

        public string RUT { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string HashedPassword { get; set; } = null!;

        public bool IsEnabled { get; set; } = true;



        public int CareerId { get; set; }
        public Career Career { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}