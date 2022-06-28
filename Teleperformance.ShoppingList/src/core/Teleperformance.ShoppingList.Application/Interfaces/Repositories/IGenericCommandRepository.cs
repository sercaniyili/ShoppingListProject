using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IGenericCommandRepository<T> where T : class, IBaseEntity
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
    
    
}
