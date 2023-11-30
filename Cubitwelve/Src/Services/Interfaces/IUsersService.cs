using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.DTOs.Profile;
using Cubitwelve.Src.DTOs.Progress;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<UserDto>> GetAll();

        public Task<UserDto> GetById(int id);

        public Task<UserDto> GetByEmail(string email);

        public Task<UserDto> EditProfile(EditProfileDto editProfileDto);

        public Task<bool> IsEnabled(string email);

        public Task<UserDto> GetProfile();

        public Task<List<UserProgressDto>> GetUserProgress();

        
    }
}