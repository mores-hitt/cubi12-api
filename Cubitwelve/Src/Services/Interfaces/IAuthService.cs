using Cubitwelve.Src.DTOs.Auth;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        
    }
}