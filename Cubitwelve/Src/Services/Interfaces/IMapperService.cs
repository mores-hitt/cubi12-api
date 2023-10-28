

using Cubitwelve.Src.DTOs;
using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IMapperService
    {
        public User RegisterClientDtoToUser(RegisterStudentDto registerStudentDto);
    }
}