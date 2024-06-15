using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        public readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool IsValidSellerInInformation(Seller seller)
        {
            var sellerIsExist = _repository.Exists(r => r.NationalCode == seller.NationalCode || r.UserId == seller.UserId);
            return !sellerIsExist;
        }

        public bool NationalCodeExistInDataBase(string natioanalCode)
        {
            return _repository.Exists(r => r.NationalCode == natioanalCode);
        }
    }
}
