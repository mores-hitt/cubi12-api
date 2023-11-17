namespace Cubitwelve.Src.Models
{
    public class SubjectRelationship : BaseModel
    {
        public string SubjectCode { get; set; } = null!;
        
        public string PreSubjectCode { get; set; } = null!;
    }
}