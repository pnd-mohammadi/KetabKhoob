using Common.Query;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Adrdreses.GetByList
{
    public record GetUserAddressByListQuery(long UserId) : IQuery <List<AddressDto>>
    {
    }
}
