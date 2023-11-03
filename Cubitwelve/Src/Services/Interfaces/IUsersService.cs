using Cubitwelve.Src.DTOs.Models;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<UserDto>> GetAll();

        public Task<UserDto> GetById(int id);

        public Task<UserDto> GetByEmail(string email);
    }
}