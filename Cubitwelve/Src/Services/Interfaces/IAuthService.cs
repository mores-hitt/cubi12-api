using Cubitwelve.Src.DTOs;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> RegisterStudent(RegisterStudentDto registerStudentDto);

        public Task<string?> Login(LoginUserDto loginUserDto);

        public Task<string?> EditProfile(string id, EditProfileDto editProfileDto);
    }
}