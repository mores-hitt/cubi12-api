using Cubitwelve.Src.DTOs.Resources;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class ResourcesService : IResourcesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourcesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SubjectResourceDto>> GetAllSubjectResources()
        {
            var subjectResources = await _unitOfWork.ResourcesRepository.Get();
            var mappedSubjects = subjectResources.Select(subject => new SubjectResourceDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                Semester = subject.Semester
            }).ToList();
            return mappedSubjects;
        }
    }
}