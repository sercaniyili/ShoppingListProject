using ShoppingListConsumer;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;
using Teleperformance.Bootcamp.Persistence.Context;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IMongoConnect, MongoDbConnect>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();


