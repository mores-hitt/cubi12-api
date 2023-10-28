using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cubitwelve.Src.Auth.DTOs;
using Cubitwelve.Src.DTOs.Auth;
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
        private readonly IRolesRepository _rolesRepository;

        public AuthService(IUsersRepository usersRepository, IConfiguration configuration,
                            IMapperService mapperService, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _mapperService = mapperService;
            _rolesRepository = rolesRepository;
        }

        public async Task<LoginResponseDto?> EditProfile(int id, EditProfileDto editProfileDto)
        {
            var user = await _usersRepository.GetById(id);
            if (user is null) return null;

            user.Name = editProfileDto.Name;
            user.FirstLastName = editProfileDto.FirstLastName;
            user.SecondLastName = editProfileDto.SecondLastName;
            user.Career = editProfileDto.Career;
            user.Email = editProfileDto.Email;

            var updatedUser = _usersRepository.Update(user);

            var jwt = CreateToken(updatedUser);

            return new LoginResponseDto
            {
                Name = updatedUser.Name,
                FirstLastName = updatedUser.FirstLastName,
                SecondLastName = updatedUser.SecondLastName,
                RUT = updatedUser.RUT,
                Email = updatedUser.Email,
                Career = updatedUser.Career,
                Jwt = jwt
            };
        }

        public async Task<LoginResponseDto?> Login(LoginUserDto loginUserDto)
        {
            var user = await _usersRepository.GetByEmail(loginUserDto.Email);
            if (user is null) return null;

            var result = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.HashedPassword);
            if (!result) return null;

            var jwt = CreateToken(user);
            return new LoginResponseDto
            {
                Name = user.Name,
                FirstLastName = user.FirstLastName,
                SecondLastName = user.SecondLastName,
                RUT = user.RUT,
                Email = user.Email,
                Career = user.Career,
                Jwt = jwt
            };
        }

        public async Task<LoginResponseDto?> RegisterStudent(RegisterStudentDto registerStudentDto)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerStudentDto.Password, salt);

            var mappedUser = _mapperService.RegisterClientDtoToUser(registerStudentDto);
            // Ensure fill fields not mapped
            mappedUser.HashedPassword = passwordHash;
            mappedUser.RoleId = _rolesRepository.GetStudentRole().Id;

            var user = await _usersRepository.Add(mappedUser);
            var jwt = CreateToken(user);
            return new LoginResponseDto
            {
                Name = user.Name,
                FirstLastName = user.FirstLastName,
                SecondLastName = user.SecondLastName,
                RUT = user.RUT,
                Email = user.Email,
                Career = user.Career,
                Jwt = jwt
            };
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