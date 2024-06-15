using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    public record GetSliderByIdQuery( long SliderId) :IQuery<SliderDto>
    {
    }
    public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private readonly ShopContext _context;

        public GetSliderByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider=await _context.Sliders.FirstOrDefaultAsync(s=>s.Id == request.SliderId);
            if (slider == null)
                return null;
            return new SliderDto()
            {
                ImageName= slider.ImageName,
                Link= slider.Link,
                Title= slider.Title,
            };
        }
    }
}
