using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Cache;

namespace Teleperformance.Bootcamp.Infrastructure.Services.Cache
{
    public class RedisDistrubutedCacheService : IRedisDistrubutedCache
    {
        private readonly IDistributedCache  _distributedCache;
        public RedisDistrubutedCacheService(IDistributedCache distributedCache)=> _distributedCache = distributedCache;

        public async Task<TEntity> GetObjectAsync<TEntity>(string key)
        {
            string serializedUsers=String.Empty;

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var cachedValue = await _distributedCache.GetAsync(key);
            if (cachedValue != null)
            serializedUsers = Encoding.UTF8.GetString(cachedValue);

            return JsonSerializer.Deserialize<TEntity>(cachedValue);
        }


        public async Task SetObjectAsync<TEntity>(string key, TEntity value, int absoluteExpirationMinute = 1, int slidingExpirationSecond = 10)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            var distributedCacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinute),
                SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSecond)
            };

            var serilazedValue = JsonSerializer.Serialize(value);

            await _distributedCache.SetStringAsync(key, serilazedValue, distributedCacheEntryOptions);
        }
    }
}
