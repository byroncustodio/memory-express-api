using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using MemoryExpress.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MemoryExpress.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public EfRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().AsQueryable().CountAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable().Where(predicate);
        }

        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}