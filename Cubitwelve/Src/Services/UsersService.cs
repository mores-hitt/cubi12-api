using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.DTOs.Profile;
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

        #region PRIVATE_METHODS

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

        #endregion

    }
}