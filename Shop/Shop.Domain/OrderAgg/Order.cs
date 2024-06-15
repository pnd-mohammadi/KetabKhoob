using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Events;
using Shop.Domain.OrderAgg.ValueObjects;
using System.Data;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order() { }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }
        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public OrderDiscount Discount { get; private set; }
        public OrderShippingMethod ShippingMethod { get; private set; }
        public OrderAddress Address { get; private set; }
        public DateTime LastUpdate { get; set; }
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);
                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }
        public int ItemCount => Items.Count;

        public void AddItem(OrderItem Item)
        {
            var oldItem = Items.FirstOrDefault(r => r.InventoryId == Item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(Item.Count + oldItem.Count);
                return;
            }
            Items.Add(Item);
        }
        public void RemoveItem(long ItemId)
        {
            var currentItem = Items.FirstOrDefault(r => r.Id == ItemId);
            if (currentItem == null)
                return;
            Items.Remove(currentItem);
        }
        public void IncreaseItemCount(long ItemId,int Count)
        {
            var currentItem = Items.FirstOrDefault(r => r.Id == ItemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();
            currentItem.IncreaseCount(Count);
        }
        public void DecreaseItemCount(long ItemId, int Count)
        {
            var currentItem = Items.FirstOrDefault(r => r.Id == ItemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException(); ;
            currentItem.DecreaseCount(Count);
        }
        public void ChangeCountItem(long itemId, int newCount)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.ChangeCount(newCount);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status=status;
            LastUpdate = DateTime.Now;
        }
        public void Checkout(OrderAddress address,OrderShippingMethod shippingMethod)
        {
            ChangeOrderGuard();
            Address=address;
            ShippingMethod = shippingMethod;    
        }
        public void Finally()
        {
            Status = OrderStatus.Finally;
            LastUpdate = DateTime.Now;
            AddDomainEvent(new OrderFinallized(Id));
        }
        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("مکان ویرایش این سفارش وجود ندارد");
        }
    }
}
