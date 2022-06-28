using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>:IGenericCommandRepository<T>,IGenericQueryRepository<T> where T : class,IBaseEntity{}
}
