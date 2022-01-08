using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentTeacher.Core.Models;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Service.Filters.ActionFilters;

public class ValidateStudentExistsForTeacher : IAsyncActionFilter
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ValidateStudentExistsForTeacher(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository; _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var method = context.HttpContext.Request.Method;
        var trackChanges = method.Equals("PUT") ? true : false;

        var teacherId = (int)context.ActionArguments["teacherId"];
        var teacher = await _repository.Teacher.GetTeacher(teacherId, false);

        if (teacher is null)
        {
            _logger.LogInfo($"Teacher with id: {teacherId} doesn't exist in the database.");
            var response = new ObjectResult(new ResponseModel
            {
                StatusCode = 404,
                Message = $"Teacher with id: {teacherId} doesn't exist in the database."
            });
            context.Result = response;
            return;
        }
        var id = (int)context.ActionArguments[context.ActionArguments.Keys.Where(x => x.Equals("id") || x.Equals("studentId")).SingleOrDefault()];
        var student = await _repository.Student.GetStudent(teacherId, id, trackChanges);

        if (student == null)
        {
            _logger.LogInfo($"Student with id: {id} doesn't exist in the database.");
            var response = new ObjectResult(new ResponseModel
            {
                StatusCode = 404,
                Message = $"Student with id: {id} doesn't exist in the database."
            });
            context.Result = response;
        }
        else
        {
            context.HttpContext.Items.Add("student", student);
            await next();
        }
    }
}
