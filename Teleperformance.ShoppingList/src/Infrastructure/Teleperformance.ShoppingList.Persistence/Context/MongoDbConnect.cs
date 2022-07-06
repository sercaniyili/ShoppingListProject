using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;

namespace Teleperformance.Bootcamp.Persistence.Context
{
    public class MongoDbConnect : IMongoConnect
    {
        private readonly IConfiguration _configuration;
        public MongoDbConnect(IConfiguration configuration) => _configuration = configuration;

        public IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("Denemeikinci");
            return db.GetCollection<T>(collection);
        }
    }
}
