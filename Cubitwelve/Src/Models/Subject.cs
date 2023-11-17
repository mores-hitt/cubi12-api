namespace Cubitwelve.Src.Models
{
    public class Subject : BaseModel
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public int Credits { get; set; }

        public int Semester { get; set; } // Represents the semester in which the subject is taught.
    }
}