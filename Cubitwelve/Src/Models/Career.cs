using System.ComponentModel.DataAnnotations;

namespace Cubitwelve.Src.Models
{
    public class Career : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; } = null!;
    }
}