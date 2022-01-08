using AutoMapper;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Mappings;

public class TeacherMappingProfile : Profile
{
    public TeacherMappingProfile()
    {
        CreateMap<Teacher, TeacherDto>();

        CreateMap<TeacherCreationDto, Teacher>();

        CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();
    }
}
