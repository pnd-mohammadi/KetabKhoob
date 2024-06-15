using Common.Application;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.EditInventory
{
    public class EditInventorySellerCommandHandler : IBaseCommandHandler<EditInventorySellerCommand>
    {
        public readonly ISellerRepository _repository;

        public EditInventorySellerCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditInventorySellerCommand request, CancellationToken cancellationToken)
        {
            var seller =await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            seller.EditInventory(request.InventoryId, request.Count,request.Price, request.DisCountPercentage);
            await _repository.Save();
            return OperationResult.Success();   
        }
    }
    
}
