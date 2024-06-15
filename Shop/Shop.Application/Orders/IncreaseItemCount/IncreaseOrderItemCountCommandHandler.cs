using Common.Application;
using Shop.Domain.OrderAgg;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
    {
        public readonly IOrderRepository _repository;

        public IncreaseOrderItemCountCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.IncreaseItemCount(request.ItemId, request.count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

    

