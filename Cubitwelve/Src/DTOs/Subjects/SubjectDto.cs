using Cubitwelve.Src.DTOs.Models;

namespace Cubitwelve.Src.DTOs.Subjects
{
    public class SubjectDto : BaseModelDto
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Department { get; set; } = null!;

        public int Credits { get; set; }
    }
}