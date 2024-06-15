﻿using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<Order> GetCurrentUserOrder(long userId);
    }
}
