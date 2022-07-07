using MongoDB.Driver;

namespace Teleperformance.Bootcamp.Application.Interfaces.Contract
{
    public interface IMongoConnect
    {
        public IMongoCollection<T> ConnectToMongo<T>(string collection);
    }
}
