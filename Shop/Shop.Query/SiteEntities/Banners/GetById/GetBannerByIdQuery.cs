using Common.Query;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Banners.GetById
{
    public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>
    {
    }

}
