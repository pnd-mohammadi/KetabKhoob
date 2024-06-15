using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.EditInventory
{
    public class EditInventorySellerCommand:IBaseCommand
    {
        public EditInventorySellerCommand(long sellerId, long inventoryId, int price, int count, int disCountPercentage)
        {
            SellerId = sellerId;
            InventoryId = inventoryId;
            Price = price;
            Count = count;
            DisCountPercentage = disCountPercentage;
        }

        public long SellerId { get; private set; }
        public long InventoryId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int DisCountPercentage { get; private set; }
    }
    
}
