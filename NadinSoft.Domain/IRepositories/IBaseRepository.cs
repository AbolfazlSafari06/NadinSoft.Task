using System.Linq.Expressions;

namespace NadinSoft.Domain.IRepositories;
public interface IBaseRepository<TId, T> where T : class
{
    Task<List<T>> GetListAsync();
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> query);
    Task<bool> AnyAsync(Expression<Func<T, bool>> query);
    Task<T?> GetByIdAsync(TId id);
    Task<T> CreateAsync(T command);
    Task RemoveByIdAsync(T id);
    Task SaveChangesAsync();
}