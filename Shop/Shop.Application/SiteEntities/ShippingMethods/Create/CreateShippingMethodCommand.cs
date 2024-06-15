using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.ShippingMethods.Create
{
    public class CreateShippingMethodCommand:IBaseCommand
    {
        public CreateShippingMethodCommand(string title, int cost)
        {
            Title = title;
            Cost = cost;
        }

        public string Title { get; private set; }
        public int Cost { get; private set; }
    }

}
