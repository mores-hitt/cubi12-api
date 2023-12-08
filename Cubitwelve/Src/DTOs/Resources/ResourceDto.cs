using Cubitwelve.Src.DTOs.Models;

namespace Cubitwelve.Src.DTOs.Resources
{
    public class ResourceDto : BaseModelDto
    {
        public string Type { get; set; } = null!;

        public int TypeCode { get; set; }

        public string Url { get; set; } = null!;

        public int SubjectResourceId { get; set; }
    }
}