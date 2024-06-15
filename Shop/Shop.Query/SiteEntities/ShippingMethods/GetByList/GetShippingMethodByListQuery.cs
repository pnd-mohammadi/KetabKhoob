using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.ShippingMethods.GetByList
{
    public class GetShippingMethodByListQuery:IQuery<List<ShippingMethodDto>>
    {

    }
    public class GetShippingMethodByListQueryHandler : IQueryHandler<GetShippingMethodByListQuery, List<ShippingMethodDto>>
    {
        private readonly ShopContext _context;

        public GetShippingMethodByListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodByListQuery request, CancellationToken cancellationToken)
        {
            return await _context.ShippingMethods
            .Select(sh=> new ShippingMethodDto()
            {
                Id = sh.Id,
                CreationDate = sh.CreationDate,
                Title= sh.Title,
                Cost= sh.Cost,
            }).ToListAsync(cancellationToken);

        }
    }
}
