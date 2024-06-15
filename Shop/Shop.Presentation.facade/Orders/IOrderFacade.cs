using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCout;
using Shop.Application.Orders.Finally;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Application.Orders.SendOrder;
using Shop.Query.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Orders
{
    public interface IOrderFacade
    {
        Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
        Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
        Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
        Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
        Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);
        Task<OperationResult> FinallyOrder(OrderFinallyCommand command);
        Task<OperationResult> SendOrder(long orderId);



        Task<OrderDto?> GetOrderById(long orderId);
        Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParam filterParams);
        Task<OrderDto?> GetCurrentOrder(long userId);




    }
}
