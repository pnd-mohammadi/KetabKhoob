using Common.Application;
using Shop.Application.SiteEntities.ShippingMethods.Create;
using Shop.Application.SiteEntities.ShippingMethods.Edit;
using Shop.Query.SiteEntities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SiteEntities.ShippingMethod
{
    public interface IShippingMethodFacade
    {
        Task<OperationResult> Create(CreateShippingMethodCommand command);
        Task<OperationResult> Edit(EditShippingMethodCommand command);
        Task<OperationResult> Delete(long id);


        Task<ShippingMethodDto?> GetShippingMethodById(long id);
        Task<List<ShippingMethodDto>> GetList();

    }
}
