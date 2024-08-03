using MicroServiceShop.Order.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MicroServiceShop.Order.Infrastructure.Repositories
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public EntityRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByFiltereAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(filter);
            return entity == null ? throw new KeyNotFoundException($"Entity not found.") : entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity == null ? throw new KeyNotFoundException($"Entity not found.") : entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
