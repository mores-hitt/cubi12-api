

using Cubitwelve.Src.Auth.DTOs;
using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface IMapperService
    {
        public User RegisterClientDtoToUser(RegisterStudentDto registerStudentDto);
        public User EditProfileDtoToUser(EditProfileDto editProfileDto);
    }
}