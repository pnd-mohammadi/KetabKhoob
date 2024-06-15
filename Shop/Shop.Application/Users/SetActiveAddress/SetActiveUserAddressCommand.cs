using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.SetActiveAddress
{
    public class SetActiveUserAddressCommand:IBaseCommand
    {
        public SetActiveUserAddressCommand(long userId, long addressId)
        {
            UserId = userId;
            AddressId = addressId;
        }

        public long UserId { get; private set; }
        public long AddressId { get;private set; }
    }
}
