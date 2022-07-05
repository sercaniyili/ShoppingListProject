using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Bootcamp.Application.Interfaces.MessageBrokers
{
    public interface IRabbitmqService
    {
        void Publish<T>(T value, string exchangeType, string exchangeName, string queueName, string? routeKey);
    }
}
