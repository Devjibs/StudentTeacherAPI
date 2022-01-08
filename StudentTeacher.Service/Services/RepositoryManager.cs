using StudentTeacher.Repo.Data;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Service.Services;

public class RepositoryManager : IRepositoryManager
{
    private RepositoryContext _repositoryContext;

    private ITeacherRepository _teacherRepository;
    private IStudentRepository _studentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public ITeacherRepository Teacher
    {
        get
        {
            if (_teacherRepository is null)
                _teacherRepository = new TeacherRepository(_repositoryContext);
            return _teacherRepository;
        }
    }
    public IStudentRepository Student
    {
        get
        {
            if (_studentRepository is null)
                _studentRepository = new StudentRepository(_repositoryContext);
            return _studentRepository;
        }
    }
    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
}
