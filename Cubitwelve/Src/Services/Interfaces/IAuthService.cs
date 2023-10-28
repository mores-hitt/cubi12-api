using Cubitwelve.Src.Auth.DTOs;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> RegisterStudent(RegisterStudentDto registerStudentDto);

        public Task<string?> Login(LoginUserDto loginUserDto);

        public Task<string?> EditProfile(int id, EditProfileDto editProfileDto);
    }
}