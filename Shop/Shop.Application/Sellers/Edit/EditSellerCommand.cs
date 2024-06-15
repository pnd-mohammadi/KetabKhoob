﻿using Common.Application;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long SellerId, string ShopName, string NationalCode , SellerStatus Status) :IBaseCommand
    {
      
    }
}
