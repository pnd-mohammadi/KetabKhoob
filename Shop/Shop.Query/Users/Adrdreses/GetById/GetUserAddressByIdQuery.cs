using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Adrdreses.GetById
{
    public record GetUserAddressByIdQuery(long AddressId) : IQuery<AddressDto?>
    {

    }
}
