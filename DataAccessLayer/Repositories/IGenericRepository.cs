using System.Linq.Expressions;
using OrderDelivery.Models;

namespace OrderDelivery.DataAccessLayer.Repositories;

public interface IGenericRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync(bool isAsNoTracking = false);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool isAsNoTracking = false);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool isAsNoTracking = false);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, bool isAsNoTracking = false);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<int> SaveChangesAsync();
}