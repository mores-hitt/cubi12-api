namespace Cubitwelve.Src.Models;

public class Resource : BaseModel
{
    public string Type { get; set; } = null!;

    public int TypeCode { get; set; }

    public string Url { get; set; } = null!;

    public SubjectResource SubjectResource { get; set; } = null!;

    public int SubjectResourceId { get; set; }
}