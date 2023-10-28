using Cubitwelve.Src.DTOs;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapperService _mapperService;

        public AuthService(IUsersRepository usersRepository, IConfiguration configuration,
                            IMapperService mapperService)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _mapperService = mapperService;
        }

        public async Task<string?> Login(LoginUserDto loginUserDto)
        {
            return "jwt";
        }

        public async Task<string> RegisterClient(RegisterStudentDto registerClientDto)
        {
            return "jwt";
        }
    }
}