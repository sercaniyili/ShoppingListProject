using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IGenericCommandRepository<T> where T : class, IBaseEntity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        void Update(T entity);
        Task DeleteAsync(string id);
    }
}
