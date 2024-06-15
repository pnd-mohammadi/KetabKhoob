using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.ShippingMethods.Edit
{
    public class EditShippingMethodCommand:IBaseCommand
    {
        public long ShippingId { get;private set; }
        public string Title { get; private set; }
        public int Cost { get; private set; }
    }
}
