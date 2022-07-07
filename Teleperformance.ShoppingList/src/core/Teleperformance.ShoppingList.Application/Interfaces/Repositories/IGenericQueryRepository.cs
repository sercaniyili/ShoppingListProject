using System.Linq.Expressions;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IGenericQueryRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(string id);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
