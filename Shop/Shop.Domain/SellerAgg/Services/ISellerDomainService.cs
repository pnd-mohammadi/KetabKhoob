﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        bool IsValidSellerInInformation(Seller seller);
        bool NationalCodeExistInDataBase(string natioanalCode);
    }
}
