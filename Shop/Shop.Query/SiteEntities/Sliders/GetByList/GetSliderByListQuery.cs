using Common.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Sliders.GetByList
{
    public class GetSliderByListQuery :IQuery<List<SliderDto>>
    {

    }

    public class GetSliderByListQueryHandler : IQueryHandler<GetSliderByListQuery, List<SliderDto>>
    {
        private readonly ShopContext _context;

        public GetSliderByListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<SliderDto>> Handle(GetSliderByListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.OrderByDescending(d => d.Id)
                .Select(slider => new SliderDto()
                {
                    Id = slider.Id,
                    CreationDate = slider.CreationDate,
                    ImageName = slider.ImageName,
                    Link = slider.Link,
                    Title = slider.Title
                }).ToListAsync(cancellationToken);
        }

    }
}
