using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IGenericCommandRepository<T>, IGenericQueryRepository<T> where T : class, IBaseEntity { }
}
