using AutoMapper;
using Cubitwelve.Src.DTOs;
using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterStudentDto, User>();
        }
    }
}