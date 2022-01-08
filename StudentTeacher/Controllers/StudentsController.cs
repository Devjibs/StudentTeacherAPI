using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;
using StudentTeacher.Service.Filters.ActionFilters;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Controllers;


[Route("api/teachers/{teacherId}/students")]
//[ApiController] 
public class StudentsController : BaseApiController
{
    public StudentsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
    {
    }


    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ServiceFilter(typeof(ValidateTeacherExists))]
    public async Task<IActionResult> CreateStudentForTeacher(int teacherId, [FromBody] StudentCreationDto student)
    {
        var studentData = _mapper.Map<Student>(student);
        await _repository.Student.CreateStudentForTeacher(teacherId, studentData);
        await _repository.SaveAsync();
        var studentReturn = _mapper.Map<StudentDto>(studentData);
        return Ok(studentReturn);
    }


    [HttpPut("{id}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ServiceFilter(typeof(ValidateStudentExistsForTeacher))]
    public async Task<IActionResult> UpdateStudentForTeacher(int teacherId, int id, [FromBody] StudentUpdateDto student)
    {
        var studentData = HttpContext.Items["student"] as Student;
        _mapper.Map(student, studentData);
        await _repository.SaveAsync();
        return NoContent();
    }


    [HttpGet]
    [ServiceFilter(typeof(ValidateStudentExistsForTeacher))]
    public async Task<IActionResult> GetStudent(int teacherId, int studentId)
    {
        try
        {
            var student = await _repository.Student.GetStudent(teacherId, studentId, trackChanges: false);
            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetStudent)} action {ex}");
            return StatusCode(500, "Internal server error");
        }
    }
}
