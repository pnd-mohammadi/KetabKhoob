using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Delete;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.Banners.GetByList;
using Shop.Query.SiteEntities.DTOS;
using Shop.Query.SiteEntities.Sliders.GetById;
using Shop.Query.SiteEntities.Sliders.GetByList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.SiteEntities.Slider
{
    internal class SliderFacade : ISliderFacade
    {
        private readonly IMediator _mediator;

        public SliderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteSlider(long sliderId)
        {
            return await _mediator.Send(new DeleteSliderCommand(sliderId));
        }

        public async Task<OperationResult> EditSlider(EditSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SliderDto?> GetSliderById(long id)
        {
            return await _mediator.Send(new GetSliderByIdQuery(id));
        }

        public async Task<List<SliderDto>> GetSliders()
        {
            return await _mediator.Send(new GetSliderByListQuery());
        }
    }
}
