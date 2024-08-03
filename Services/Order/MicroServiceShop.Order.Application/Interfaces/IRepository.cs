﻿using System.Linq.Expressions;


namespace MicroServiceShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByFiltereAsync(Expression<Func<T, bool>> filter);
    }
}
