using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Application.Interfaces.Cache
{
    public interface IRedisDistrubutedCache
    {
        Task<TEntity> GetObjectAsync<TEntity>(string key);
        Task SetObjectAsync<TEntity>(string key, TEntity value, int absoluteExpirationMinute = 1,
            int slidingExpirationSecond = 10);

    }
}
