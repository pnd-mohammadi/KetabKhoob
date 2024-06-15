using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.ShippingMethods.Create;
using Shop.Application.SiteEntities.ShippingMethods.Delete;
using Shop.Application.SiteEntities.ShippingMethods.Edit;
using Shop.Query.SiteEntities.DTOS;
using Shop.Query.SiteEntities.ShippingMethods.GetById;
using Shop.Query.SiteEntities.ShippingMethods.GetByList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.SiteEntities.ShippingMethod
{
    public class ShippingMethodFacade : IShippingMethodFacade
    {
        private readonly IMediator _mediator;

        public ShippingMethodFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateShippingMethodCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Delete(long id)
        {
           return await _mediator.Send(new DeleteShippingMethodCommad(id));
    }

        public async Task<OperationResult> Edit(EditShippingMethodCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<ShippingMethodDto>> GetList()
        {
            return await _mediator.Send(new GetShippingMethodByListQuery());
        }

        public async Task<ShippingMethodDto?> GetShippingMethodById(long id)
        {
            return await _mediator.Send(new GetShippingMethodByIdQuery(id));
        }
    }
}
