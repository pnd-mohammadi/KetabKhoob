using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOS;

namespace Shop.Query.SiteEntities.Banners.GetByList
{
    public class GetBannerByListQueryHandler : IQueryHandler<GetBannerByListQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;

        public GetBannerByListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<BannerDto>> Handle(GetBannerByListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.OrderByDescending(b => b.Id)
                        .Select(s => new BannerDto()
                        {
                            Id = s.Id,
                            CreationDate = s.CreationDate,
                            ImageName = s.ImageName,
                            Link = s.Link,
                            Position = s.Position

                        }).ToListAsync(cancellationToken);
        }
    }
}
