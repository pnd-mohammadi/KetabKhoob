using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(long inventoryId, int count, int price)
        {
            CountGuard(count);
            PriceGuard(price);

            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Count * Price;  
        
        public void IncreaseCount(int newCount)
        {
            Count += newCount;
        }
        public void DecreaseCount(int count)
        {
            if (count < 1) return;
            if (Count - count <= 0) return;
            Count -= count;
        }
        public void ChangeCount(int newcount)
        {
            CountGuard(newcount);
            Count = newcount;
        }
        public void SetPrice(int newprice)
        {
            PriceGuard(newprice);
            Price = newprice;
        }
        public void CountGuard(int count)
        {
            if (count < 1)
                 throw new NullOrEmptyDomainDataException("تعداد نامعتبر است");
        }
        public void PriceGuard(int newprice)
        {
            if (newprice < 1)
                throw new NullOrEmptyDomainDataException("میلغ نامعتبر است");
        }
    }
}
