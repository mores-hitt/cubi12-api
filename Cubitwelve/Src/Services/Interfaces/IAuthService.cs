using Cubitwelve.Src.Auth.DTOs;
using Cubitwelve.Src.DTOs.Auth;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto?> RegisterStudent(RegisterStudentDto registerStudentDto);

        public Task<LoginResponseDto?> Login(LoginUserDto loginUserDto);

        public Task<LoginResponseDto?> EditProfile(int id, EditProfileDto editProfileDto);
    }
}