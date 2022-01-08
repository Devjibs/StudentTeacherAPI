using AutoMapper;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;

namespace StudentTeacher.Core.Mappings;
public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentDto>();

        CreateMap<StudentCreationDto, Student>();

        CreateMap<StudentUpdateDto, Student>().ReverseMap();
    }
}
