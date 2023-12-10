using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.DTOs.Profile;
using Cubitwelve.Src.DTOs.Progress;
using Cubitwelve.Src.DTOs.Subjects;
using Cubitwelve.Src.Exceptions;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;
        private readonly IAuthService _authService;

        public UsersService(IUnitOfWork unitOfWork, IMapperService mapperService, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
            _authService = authService;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _unitOfWork.UsersRepository.GetAll();
            return _mapperService.MapList<User, UserDto>(users);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await GetUserByEmail(email);
            return _mapperService.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await GetUserById(id);
            return _mapperService.Map<User, UserDto>(user);
        }

        public async Task<UserDto> EditProfile(EditProfileDto editProfileDto)
        {
            var userEmail = _authService.GetUserEmailInToken();
            var user = await GetUserByEmail(userEmail);
            // UpdateFields
            user.Name = editProfileDto.Name;
            user.FirstLastName = editProfileDto.FirstLastName;
            user.SecondLastName = editProfileDto.SecondLastName;

            var updatedUser = await _unitOfWork.UsersRepository.Update(user);

            return _mapperService.Map<User, UserDto>(updatedUser);
        }

        public async Task<bool> IsEnabled(string email)
        {
            try
            {
                var user = await GetUserByEmail(email);
                if (!user.IsEnabled)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<UserDto> GetProfile()
        {
            var userEmail = _authService.GetUserEmailInToken();
            return GetByEmail(userEmail);
        }


        public async Task<List<UserProgressDto>> GetUserProgress()
        {
            var userId = await GetUserIdByToken();

            var userProgress = await _unitOfWork.UsersRepository.GetProgressByUser(userId) ?? new List<UserProgress>();

            var mappedProgress = userProgress.Select(up => new UserProgressDto()
            {
                Id = up.Id,
                SubjectCode = up.Subject.Code,
            }).ToList();

            return mappedProgress;
        }


        public async Task SetUserProgress(UpdateUserProgressDto subjects)
        {
            var subjectsId = await MapAndValidateToSubjectId(subjects);
            var subjectsToAdd = subjectsId.Item1;
            var subjectsToDelete = subjectsId.Item2;

            var userId = await GetUserIdByToken();
            // Get Current User Progress
            var userProgress = await _unitOfWork.UsersRepository.GetProgressByUser(userId) ?? new List<UserProgress>();

            var progressToAdd = subjectsToAdd.Select(s =>
            {
                var foundUserProgress = userProgress.FirstOrDefault(up => up.SubjectId == s);

                if (foundUserProgress is not null)
                    throw new DuplicateEntityException($"Subject with ID: {foundUserProgress.Subject.Code} already exists");

                return new UserProgress()
                {
                    SubjectId = s,
                    UserId = userId,
                };
            }).ToList();

            var progressToRemove = subjectsToDelete.Select(s =>
            {
                if (userProgress.FirstOrDefault(up => up.SubjectId == s) is null)
                    throw new EntityNotFoundException($"Subject with ID: {s} not found");

                return new UserProgress()
                {
                    SubjectId = s,
                    UserId = userId,
                };
            }).ToList();

            var addResult = await _unitOfWork.UsersRepository.AddProgress(progressToAdd);
            var removeResult = await _unitOfWork.UsersRepository.RemoveProgress(progressToRemove, userId);

            if (!removeResult && !addResult)
                throw new InternalErrorException("Cannot update user progress");
        }

        #region PRIVATE_METHODS

        private async Task<Tuple<List<int>, List<int>>> MapAndValidateToSubjectId(UpdateUserProgressDto subjects)
        {
            var allSubjects = await _unitOfWork.SubjectsRepository.Get();
            var subjectsToAdd = subjects.AddSubjects;
            var subjectsToDelete = subjects.DeleteSubjects;

            var mappedSubjectsToAdd = subjectsToAdd.Select(s =>
            {
                s = s.ToLower();
                var foundSubject = allSubjects.FirstOrDefault(sub => sub.Code == s)
                    ?? throw new EntityNotFoundException($"Subject with ID: {s} not found");
                return foundSubject.Id;
            }).ToList();

            var mappedSubjectsToDelete = subjectsToDelete.Select(s =>
            {
                s = s.ToLower();
                var foundSubject = allSubjects.FirstOrDefault(sub => sub.Code == s)
                    ?? throw new EntityNotFoundException($"Subject with ID: {s} not found");
                return foundSubject.Id;
            }).ToList();

            return new Tuple<List<int>, List<int>>(mappedSubjectsToAdd, mappedSubjectsToDelete);

        }

        private async Task<User> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.UsersRepository.GetByEmail(email)
                                        ?? throw new EntityNotFoundException($"User with email: {email} not found");
            return user;
        }

        private async Task<User> GetUserById(int id)
        {
            var user = await _unitOfWork.UsersRepository.GetByID(id)
                                        ?? throw new EntityNotFoundException($"User with ID: {id} not found");
            return user;
        }

        private async Task<int> GetUserIdByToken()
        {
            var userEmail = _authService.GetUserEmailInToken();
            var user = await _unitOfWork.UsersRepository.GetByEmail(userEmail) ??
                          throw new EntityNotFoundException("User not found");
            return user.Id;
        }

        #endregion

    }
}