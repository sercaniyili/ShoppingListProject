using RabbitMQ.Client;

namespace Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers
{
    public interface IRabbitmqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}
