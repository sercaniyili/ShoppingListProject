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
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext appDbContext) => (_appDbContext, _dbSet) 
            = (appDbContext, _appDbContext.Set<T>());
      
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var current = _dbSet.FirstOrDefault(x => x.Id == id);
            if (current == null) throw new Exception("");

            _dbSet.Remove(current);
            _appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _appDbContext.Entry<T>(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (_dbSet == null) throw new Exception("");
            return await _dbSet.FindAsync();
        }

    }
}
