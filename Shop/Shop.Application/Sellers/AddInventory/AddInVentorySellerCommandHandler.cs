using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddInVentorySellerCommandHandler : IBaseCommandHandler<AddInVentorySellerCommand>
    {
        public readonly ISellerRepository _repository;

        public AddInVentorySellerCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddInVentorySellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            var inventory = new SellerInvetory(request.ProductId, request.Count, request.Price, request.DisCountPercentage);
            seller.AddInventory(inventory);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
   
}
