using ShoppingListConsumer;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;
using Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers;
using Teleperformance.Bootcamp.Infrastructure.Services.MessageBrokers;
using Teleperformance.Bootcamp.Persistence.Context;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IMongoConnect, MongoDbConnect>();
        services.AddTransient<IRabbitmqConnection, RabbitmqConnection>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();


