using Common.Application;
using Shop.Domain.OrderAgg;

namespace Shop.Application.Orders.SendOrder
{
    public class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
    {
        public readonly IOrderRepository _orderRepository;

        public SendOrderCommandHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetTracking(request.OrderId);
            if (order == null)
                return OperationResult.NotFound();

            order.ChangeStatus(OrderStatus.Shipping);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
