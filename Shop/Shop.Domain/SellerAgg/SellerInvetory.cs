using Common.Domain;
using Common.Domain.Exceptions;
using System.Runtime.Versioning;

namespace Shop.Domain.SellerAgg
{
    public class SellerInvetory:BaseEntity
    {
        public SellerInvetory(long productId, int price, int count, int disCountPercentage)
        {
            Guard(price, count);
            ProductId = productId;
            Price = price;
            Count = count;
            DisCountPercentage = disCountPercentage;
        }
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int DisCountPercentage { get; private set; }

        public void Edit(int count,int price,  int disCountPercentage)
        {
            Guard(price, count);
            Price = price;
            Count = count;
            DisCountPercentage = disCountPercentage;

        }
        public void Guard(int price, int count)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();
        }


    }
}
