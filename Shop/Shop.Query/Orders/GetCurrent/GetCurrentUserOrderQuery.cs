using Common.Query;
using Shop.Query.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.GetCurrent
{
    public record GetCurrentUserOrderQuery(long UserId) :IQuery<OrderDto?>;
}
