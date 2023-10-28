using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cubitwelve.Src.DTOs;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

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
            var user = await _usersRepository.GetByEmail(loginUserDto.Email);
            if (user is null) return null;

            var result = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.HashedPassword);
            if (!result) return null;

            var token = CreateToken(user);
            return token;
        }

        public async Task<string> RegisterClient(RegisterStudentDto registerClientDto)
        {
            return "jwt";
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>{
                new ("email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}