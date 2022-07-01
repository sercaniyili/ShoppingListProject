using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IGenericQueryRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);

    }
}
