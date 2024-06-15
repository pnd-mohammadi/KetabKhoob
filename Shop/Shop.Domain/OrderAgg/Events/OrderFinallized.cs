using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Events
{
    public class OrderFinallized : BaseDomainEvent
    {
        public OrderFinallized(long orderId)
        {
            OrderId = orderId;
        }

        public long OrderId { get; set; }
    }
}
