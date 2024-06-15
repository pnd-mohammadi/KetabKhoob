using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.Dtos;

namespace Shop.Query.Orders.GetById;

public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
{
    public readonly ShopContext _context;
    private readonly DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(ShopContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order =await _context.Orders.FirstOrDefaultAsync(f => f.Id == request.OrderId, cancellationToken);
        if (order == null)
            return null;

        var orderDto= order.Map();
        orderDto.UserFullName = await _context.Users
            .Where(u=>u.Id == orderDto.UserId)
            .Select(s=> $"{s.Name}{s.Family}")
            .FirstAsync(cancellationToken);
        orderDto.Items =await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}
