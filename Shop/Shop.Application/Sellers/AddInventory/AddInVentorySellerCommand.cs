using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddInVentorySellerCommand:IBaseCommand
    {
        public AddInVentorySellerCommand(long sellerId, long productId, 
            int price, int count, int disCountPercentage)
        {
            SellerId = sellerId;
            ProductId = productId;
            Price = price;
            Count = count;
            DisCountPercentage = disCountPercentage;
        }

        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int DisCountPercentage { get; private set; }
    }
   
}
