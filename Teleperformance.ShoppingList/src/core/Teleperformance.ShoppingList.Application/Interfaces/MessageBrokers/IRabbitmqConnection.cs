using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers
{
    public interface IRabbitmqConnection
    {
        IConnection GetRabbitMqConnection();
    }
}
