using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;

        public UsersService(IUnitOfWork unitOfWork, IMapperService mapperService)
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _unitOfWork.UsersRepository.GetAll();
            return _mapperService.MapList<User, UserDto>(users);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _unitOfWork.UsersRepository.GetByEmail(email)
                                        ?? throw new Exception("User not found");
            return _mapperService.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _unitOfWork.UsersRepository.GetByID(id)
                                        ?? throw new Exception("User not found");
            return _mapperService.Map<User, UserDto>(user);
        }
    }
}