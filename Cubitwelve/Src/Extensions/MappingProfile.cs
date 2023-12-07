using AutoMapper;
using Cubitwelve.Src.DTOs.Auth;
using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.DTOs.Subjects;
using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Career, CareerDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<User, LoginResponseDto>();
            CreateMap<RegisterStudentDto, User>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectRelationship, SubjectRelationshipDto>();
        }
    }
}