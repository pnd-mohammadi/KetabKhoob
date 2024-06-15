﻿using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SiteAgg.Repository
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(Banner banner)
        {
            Context.Banners.Remove(banner);
        }
    }
}
