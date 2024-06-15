using Common.Application;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCout;
using Shop.Application.Orders.Finally;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Application.Orders.SendOrder;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Orders.Dtos;
using Shop.Query.Orders.GetByFilter;
using Shop.Query.Orders.GetById;
using Shop.Query.Orders.GetCurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.Orders
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IMediator _mediator;

        public OrderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> FinallyOrder(OrderFinallyCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OrderDto?> GetCurrentOrder(long userId)
        {
            return await _mediator.Send(new GetCurrentUserOrderQuery(userId));
        }

        public async Task<OrderDto?> GetOrderById(long orderId)
        {
            return await _mediator.Send(new GetOrderByIdQuery(orderId));
        }

        public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParam filterParams)
        {
            return await _mediator.Send(new GetOrderByFilterQuery(filterParams));
        }

        public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> SendOrder(long orderId)
        {
            return await _mediator.Send(new SendOrderCommand(orderId));
        }
    }
}
