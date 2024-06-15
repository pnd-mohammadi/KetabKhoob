using Common.Query;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query.Filter;

namespace Shop.Query.Orders.Dtos
{
    public class OrderDto :BaseDto
    {
        public long UserId { get;  set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get;  set; }
        public List<OrderItemDto> Items { get;  set; }
        public OrderDiscount Discount { get;  set; }
        public OrderShippingMethod ShippingMethod { get;  set; }
        public OrderAddress Address { get;  set; }
        public DateTime LastUpdate { get; set; }

        public int TotlaPrice
        {
            get
            {
                var total = Items.Sum(s => s.TotalPrice);
                if (Discount != null)
                {
                    total -= Discount.DiscountAmount;
                }
                total += ShippingMethod?.ShippingCost ?? 0;
                return total;
            }
        }

    }
    public class OrderItemDto : BaseDto
    {
        public string ProductImageName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductSlug { get; set; }
        public string ShopName { get; set; }
        public long OrderId { get;  set; }
        public long InventoryId { get;  set; }
        public int Count { get;  set; }
        public int Price { get;  set; }
        public int TotalPrice => Count * Price;
    }
    public class OrderFilterData :BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public string? Shire { get; set; }
        public string? City { get; set; }
        public string? ShippingType { get; set; }
        public int TotalPrice { get; set; }
        public int TotalItemCount { get; set; }
    }
    public class OrderFilterParam :BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrderStatus? Status { get; set; }
    }
    public class OrderFilterResult : BaseFilter<OrderFilterData , OrderFilterParam>
    {

    }
}
