﻿using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Delete;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.Banners.GetById;
using Shop.Query.SiteEntities.Banners.GetByList;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SiteEntities.Banner
{
    public class BannerFacade : IBannerFacade
    {
        private readonly IMediator _mediator;

        public BannerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteBanner(long bannerId)
        {
            return await _mediator.Send(new DeleteBannerCommand(bannerId));
        }

        public async Task<OperationResult> EditBanner(EditBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<BannerDto?> GetBannerById(long id)
        {
            return await _mediator.Send(new GetBannerByIdQuery(id));
        }

        public async Task<List<BannerDto>> GetBanners()
        {
            return await _mediator.Send(new GetBannerByListQuery());
        }
    }
}
