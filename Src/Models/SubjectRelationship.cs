namespace Cubitwelve.Src.Models
{
    public class SubjectRelationship : BaseModel
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        public int PreSubjectId { get; set; }
        public Subject PreSubject { get; set; } = null!;
    }
}