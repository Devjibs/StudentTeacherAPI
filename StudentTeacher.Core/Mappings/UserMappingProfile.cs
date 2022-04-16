using AutoMapper;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Mappings;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserRegistrationDto, User>();
    }
}
