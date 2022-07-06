using MongoDB.Driver;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;


namespace Teleperformance.Bootcamp.Persistence.Context
{
    public class MongoDbConnect : IMongoConnect
    {

        public const string MongoConnectionString = "mongodb://localhost:27017";
        public const string MongoDatabaseName = "CompletedShoppingListDb";

        public IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            var client = new MongoClient(MongoConnectionString);
            var db = client.GetDatabase(MongoDatabaseName);
            return db.GetCollection<T>(collection);
        }
    }
}
