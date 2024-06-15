using Common.Query;
using Shop.Query.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParam>
    {
        public GetOrderByFilterQuery(OrderFilterParam filterParams) : base(filterParams)
        {
        }
    }
}
