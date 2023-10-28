using Cubitwelve.Src.DTOs;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> RegisterClient(RegisterStudentDto registerClientDto);

        public Task<string?> Login(LoginUserDto loginUserDto);
    }
}