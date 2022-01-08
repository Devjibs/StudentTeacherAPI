using StudentTeacher.Core.Models;

namespace StudentTeacher.Service.Interfaces;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllTeachers(bool trackChanges);
    Task<Teacher> GetTeacher(int teacherId, bool trackChanges);
    Task CreateTeacher(Teacher teacher);
}
