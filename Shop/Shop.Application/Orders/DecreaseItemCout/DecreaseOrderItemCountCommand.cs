using Common.Application;


namespace Shop.Application.Orders.DecreaseItemCout
{
    public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
