using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.Models;
using StudentTeacher.Repo.Data;
using StudentTeacher.Repo.GenericRepository.Service;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.Service.Services;

public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
{
    public TeacherRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateTeacher(Teacher teacher) => await CreateAsync(teacher);

    public async Task<IEnumerable<Teacher>> GetAllTeachers(bool trackChanges)
        => await FindAllAsync(trackChanges).Result.OrderBy(c => c.Name).ToListAsync();

    public async Task<Teacher?> GetTeacher(int teacherId, bool trackChanges)
        => await FindByConditionAsync(c => c.Id.Equals(teacherId), trackChanges).Result.SingleOrDefaultAsync();
}
