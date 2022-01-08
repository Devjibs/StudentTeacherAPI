using System.Linq.Expressions;

namespace StudentTeacher.Repo.GenericRepository.Interface;

public interface IRepositoryBase<T>
{
    Task<IQueryable<T>> FindAllAsync(bool trackChanges);
    Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}
