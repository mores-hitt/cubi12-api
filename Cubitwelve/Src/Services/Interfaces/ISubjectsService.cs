using Cubitwelve.Src.DTOs.Progress;
using Cubitwelve.Src.DTOs.Subjects;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<List<SubjectDto>> GetAll();

        public Task<List<SubjectRelationshipDto>> GetAllRelationships();

        /// <summary>
        /// Get a map of subject codes to a list of subject codes that are prerequisites for that subject
        /// </summary>
        /// <returns>Dictionary with subject key and value preRequisites subjects list</returns>
        public Task<Dictionary<string, List<string>>> GetPreRequisitesMap();

        /// <summary>
        /// Get a map of subject codes to a list of subject codes that are postrequisites for that subject
        /// </summary>
        /// <returns>Dictionary with subject key and value postRequisites subjects list</returns>
        public Task<Dictionary<string, List<string>>> GetPostRequisitesMap();
        
        /// <summary>
        /// Get all subjects passed of the current user based on the JWT token
        /// </summary>
        /// <returns>List with passed subjects</returns>
        public Task<List<UserProgressDto>> GetUserProgress();
    }
}