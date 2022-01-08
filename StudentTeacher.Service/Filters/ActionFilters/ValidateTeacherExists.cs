using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentTeacher.Core.Models;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Service.Filters.ActionFilters;

public class ValidateTeacherExists : IAsyncActionFilter
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ValidateTeacherExists(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository; _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var trackChanges = context.HttpContext.Request.Method.Equals("PUT") !;

        var id = (int)context.ActionArguments[context.ActionArguments.Keys.Where(x => x.Equals("id") || x.Equals("teacherId")).SingleOrDefault()];

        var teacher = await _repository.Teacher.GetTeacher(id, trackChanges);
        if (teacher is null)
        {
            _logger.LogInfo($"Teacher with id: {id} doesn't exist in the database.");
            var response = new ObjectResult(new ResponseModel
            {
                StatusCode = 404,
                Message = $"Teacher with id: { id} doesn't exist in the database."
            });
            context.Result = response;
        }
        else
        {
            context.HttpContext.Items.Add("teacher", teacher);
            await next();
        }
    }
}
