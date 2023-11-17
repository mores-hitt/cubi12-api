using Cubitwelve.Src.DTOs.Subjects;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<List<SubjectDto>> GetAll();
    }
}