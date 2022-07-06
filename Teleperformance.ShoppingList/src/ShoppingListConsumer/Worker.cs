using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;
using Teleperformance.Bootcamp.Domain.Entities;

namespace ShoppingListConsumer
{


    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMongoConnect _mongoDbConnect;
        private readonly IConfiguration _configuration;
        public Worker(ILogger<Worker> logger, IMongoConnect mongoConnect, IConfiguration configuration)
        {
            _logger = logger;
            _mongoDbConnect = mongoConnect;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            //string connectionString = "mongodb://localhost:27017";
            //string databaseName = "deneme123";
            //string collectionName = "deneme";

            //var client = new MongoClient(connectionString);
            //var db = client.GetDatabase(databaseName);
            //var collection = db.GetCollection<BsonShopList>(collectionName);

            var collection = _mongoDbConnect.ConnectToMongo<ShoppingListToBsonDto>
            ("DenemeListesi");
             



            while (!stoppingToken.IsCancellationRequested)
            {

                var connectioFactory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    VirtualHost = "/",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                };



                var connection = connectioFactory.CreateConnection();

                var channel = connection.CreateModel();

                channel.QueueDeclare("direct.queuName", false, false, false);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += async (sender, args) =>
                {
                    var message = JsonSerializer.Deserialize<ShoppingListToBsonDto>(Encoding.UTF8.GetString(args.Body.ToArray()));
                    foreach (PropertyInfo p in message.GetType().GetProperties())
                        Console.WriteLine(p.Name + " : " + p.GetValue(message));
                    Console.WriteLine();

                    await collection.InsertOneAsync(message);

                };

                channel.BasicConsume("direct.queuName", false, consumer);

            }
        }
    }
}