using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cubitwelve.Src.DTOs.Auth;
using Cubitwelve.Src.Exceptions;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;

namespace Cubitwelve.Src.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapperService _mapperService;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapperService mapperService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapperService = mapperService;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _unitOfWork.UsersRepository.GetByEmail(loginRequestDto.Email)
                ?? throw new UserNotFoundException("Invalid Credentials");

            var verifyPassword = BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.HashedPassword);
            if (!verifyPassword)
                throw new UserNotFoundException("Invalid Credentials");

            var token = CreateToken(user.Email, user.Role.Name);
            var response = _mapperService.Map<User, LoginResponseDto>(user);
            // Not mapped fields
            response.Token = token;
            response.Role = user.Role.Name;
            response.Career = user.Career.Name;

            return response;
        }

        private string CreateToken(string email, string role)
        {
            var claims = new List<Claim>{
                new ("email", email),
                new ("role", role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Env.GetString("JWT_SECRET")));

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