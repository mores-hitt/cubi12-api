using System.Runtime.CompilerServices;
using Cubitwelve.Src.DTOs.Progress;
using Cubitwelve.Src.DTOs.Subjects;
using Cubitwelve.Src.Exceptions;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class SubjectsService : ISubjectsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;
        private readonly IAuthService _authService;

        public SubjectsService(IUnitOfWork unitOfWork, IMapperService mapperService, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
            _authService = authService;
        }

        public async Task<List<SubjectDto>> GetAll()
        {
            var subjects = await _unitOfWork.SubjectsRepository.Get();
            return _mapperService.MapList<Subject, SubjectDto>(subjects);
        }

        public async Task<List<SubjectRelationshipDto>> GetAllRelationships()
        {
            var relationships = await _unitOfWork.SubjectRelationshipsRepository.Get();
            return _mapperService.MapList<SubjectRelationship, SubjectRelationshipDto>(relationships);
        }

        public async Task<Dictionary<string, List<string>>> GetPostRequisitesMap()
        {
            var relationshipsList = await _unitOfWork.SubjectRelationshipsRepository.Get();
            Dictionary<string, List<string>> postRequisitesMap = new();

            relationshipsList.ForEach(sr =>
            {
                if (postRequisitesMap.ContainsKey(sr.PreSubjectCode))
                {
                    postRequisitesMap[sr.PreSubjectCode].Add(sr.SubjectCode);
                }
                else
                {
                    postRequisitesMap.Add(sr.PreSubjectCode, new List<string>
                    {
                        sr.SubjectCode
                    });
                }
            });
            return postRequisitesMap;
        }

        public async Task<Dictionary<string, List<string>>> GetPreRequisitesMap()
        {
            var relationshipsList = await _unitOfWork.SubjectRelationshipsRepository.Get();
            Dictionary<string, List<string>> preRequisitesMap = new();

            relationshipsList.ForEach(sr =>
            {
                if (preRequisitesMap.ContainsKey(sr.SubjectCode))
                {
                    preRequisitesMap[sr.SubjectCode].Add(sr.PreSubjectCode);
                }
                else
                {
                    preRequisitesMap.Add(sr.SubjectCode, new List<string>
                    {
                        sr.PreSubjectCode
                    });
                }
            });
            return preRequisitesMap;
        }

        public async Task<List<UserProgressDto>> GetUserProgress()
        {
            var userEmail = _authService.GetUserEmailInToken();
            var user = await _unitOfWork.UsersRepository.GetByEmail(userEmail) ??
                          throw new EntityNotFoundException("User not found");
            var userId = user.Id;

            var userProgress = await _unitOfWork.UsersRepository.GetProgressByUser(userId) ?? new List<UserProgress>();

            var mappedProgress = userProgress.Select(up => new UserProgressDto()
            {
                Id = up.Id,
                SubjectCode = up.Subject.Code,
            }).ToList();

            return mappedProgress;
        }
    }
}
