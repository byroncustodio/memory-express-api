using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;

namespace MemoryExpress.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);
        //Task UpdateRangeAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);
        //Task DeleteRangeAsync(IEnumerable<T> entities);

        Task<int> CountAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}