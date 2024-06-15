using MediatR;
using Shop.Domain.OrderAgg.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders._EvenHandlers
{
    public class SendSmsOrderFinalizedEventHandler : INotificationHandler<OrderFinallized>
    {
        public async Task Handle(OrderFinallized notification, CancellationToken cancellationToken)
        {
            await Task.Delay(10000, cancellationToken);
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}

