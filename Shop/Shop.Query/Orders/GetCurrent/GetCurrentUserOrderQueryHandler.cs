﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.Dtos;

namespace Shop.Query.Orders.GetCurrent
{
    public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
    {
        public readonly ShopContext _shopContext;
        public readonly DapperContext _dapperContext;

        public GetCurrentUserOrderQueryHandler(ShopContext shopContext, DapperContext dapperContext)
        {
            _shopContext = shopContext;
            _dapperContext = dapperContext;
        }

        public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
        {

            var order = await _shopContext.Orders
                        .FirstOrDefaultAsync(f => f.UserId == request.UserId && f.Status == Shop.Domain.OrderAgg.OrderStatus.Pending, cancellationToken);
            if (order == null)
                return null;

            var orderDto = order.Map();
            orderDto.UserFullName = await _shopContext.Users.Where(f => f.Id == orderDto.UserId)
                .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

            orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
            return orderDto;
        }
    }
}
