using Common.Application;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.ShippingMethods.Edit
{
    public class EditShippingMethodCommandHandler : IBaseCommandHandler<EditShippingMethodCommand>
    {
        public readonly IShippingMethodRepository _repository;

        public EditShippingMethodCommandHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditShippingMethodCommand request, CancellationToken cancellationToken)
        {
            var shipping = await _repository.GetTracking(request.ShippingId);

            if (shipping == null)
                return OperationResult.NotFound();


            shipping.Edit(request.Cost, request.Title);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
