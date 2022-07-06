using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Application.Interfaces.Contract
{
    public interface IMongoConnect
    {
        public IMongoCollection<T> ConnectToMongo<T>(string collection);
    }
}
