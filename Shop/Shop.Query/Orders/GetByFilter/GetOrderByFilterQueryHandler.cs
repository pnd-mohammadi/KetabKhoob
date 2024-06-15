using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.Dtos;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
    {
        public readonly ShopContext _context;

        public GetOrderByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            var @param = request.FilterParams;
            var result = _context.Orders.OrderByDescending(r => r.Id).AsQueryable();
            if (@param.Status != null)
                result = result.Where(r => r.Status == @param.Status);
            if (@param.UserId != null)
                result = result.Where(r => r.UserId == @param.UserId);
            if (@param.StartDate != null)
                result = result.Where(r => r.CreationDate.Date >= @param.StartDate.Value.Date);
            if (@param.EndDate != null)
                result = result.Where(r => r.CreationDate.Date <= @param.EndDate.Value.Date);


            var skip = (@param.PageId - 1) * (@param.Take);

            var model = new OrderFilterResult()
            {
                Data = await result.Skip(skip).Take(@param.Take)
                     .Select(order => order.MapFilterData(_context))
                     .ToListAsync(cancellationToken),
                FilterParams = @param

            };
            model.GeneratePaginating(result, @param.Take, param.PageId);
            return model;
        }
    }
}
