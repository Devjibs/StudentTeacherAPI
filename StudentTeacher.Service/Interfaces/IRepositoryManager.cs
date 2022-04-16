namespace StudentTeacher.Service.Interfaces;

public interface IRepositoryManager
{
    ITeacherRepository Teacher { get; }
    IStudentRepository Student { get; }
    IUserAuthenticationRepository UserAuthentication { get; }
    Task SaveAsync();
}
