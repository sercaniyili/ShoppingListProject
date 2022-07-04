using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common;
using Teleperformance.Bootcamp.Persistence.Context;

namespace Teleperformance.Bootcamp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IBaseEntity
    {
        protected readonly AppDbContext _appDbContext;
        
        public GenericRepository(AppDbContext appDbContext) => (_appDbContext) = (appDbContext );

        protected DbSet<T> _dbSet => _appDbContext.Set<T>();

        //Write
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var current = await _dbSet.FindAsync(id);

             _dbSet.Remove(current);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry<T>(entity).State = EntityState.Modified;
           await _appDbContext.SaveChangesAsync();
        }


        //Read
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    
    }
}
