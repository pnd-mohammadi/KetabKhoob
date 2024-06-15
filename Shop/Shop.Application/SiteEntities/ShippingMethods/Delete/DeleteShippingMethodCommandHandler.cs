using Common.Application;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.ShippingMethods.Delete
{
    public class DeleteShippingMethodCommandHandler : IBaseCommandHandler<DeleteShippingMethodCommad>
    {
        private readonly IShippingMethodRepository _repository;

        public DeleteShippingMethodCommandHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteShippingMethodCommad request, CancellationToken cancellationToken)
        {
            var shipping = await _repository.GetTracking(request.ShippingId);
            if (shipping == null)
                return OperationResult.NotFound();

            _repository.Delete(shipping);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
    
}
