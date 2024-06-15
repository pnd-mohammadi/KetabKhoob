using Common.Application;

namespace Shop.Application.SiteEntities.ShippingMethods.Delete
{
    public class DeleteShippingMethodCommad:IBaseCommand
    {
        public DeleteShippingMethodCommad(long shippingId)
        {
            ShippingId = shippingId;
        }

        public long ShippingId { get; set; }
    }
    
}
