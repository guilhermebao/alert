using System.Linq.Expressions;

namespace Attendance.Domain.Interfaces;

public interface IBaseRepository<T, TKey> where T : class
{
    Task<T> GetByIdAsync(TKey id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    T Update(T entity);

    Task RemoveAsync(TKey id);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}
