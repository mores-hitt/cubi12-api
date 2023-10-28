using AutoMapper;
using Cubitwelve.Src.DTOs;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class MapperService : IMapperService
    {

        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public User RegisterClientDtoToUser(RegisterStudentDto registerStudentDto)
        {
            var mappedUser = _mapper.Map<User>(registerStudentDto);
            return mappedUser;
        }
    }
}