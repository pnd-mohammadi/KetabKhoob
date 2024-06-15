using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.ShippingMethods.GetById
{
    public record GetShippingMethodByIdQuery(long Id) : IQuery<ShippingMethodDto>
    {
    }

    public class GetShippingMethodByIdQueryHandler : IQueryHandler<GetShippingMethodByIdQuery, ShippingMethodDto>
    {
        private readonly ShopContext _context;

        public GetShippingMethodByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<ShippingMethodDto> Handle(GetShippingMethodByIdQuery request, CancellationToken cancellationToken)
        {
            var shippingMethod = await _context.ShippingMethods.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if (shippingMethod == null)
                return null;
            return new ShippingMethodDto()
            {
                Id = shippingMethod.Id,
                CreationDate = shippingMethod.CreationDate,
               Title= shippingMethod.Title,
               Cost= shippingMethod.Cost,

            };
        }
    }
}
