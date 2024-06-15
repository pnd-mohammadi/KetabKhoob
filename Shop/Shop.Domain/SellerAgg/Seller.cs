﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller() { }
        public Seller(long userId, string shopName, string nationalCode , ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInvetory>();

        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInvetory> Inventories { get; private set; }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
                if (domainService.NationalCodeExistInDataBase(nationalCode))
                    throw new InvalidDomainDataException("کدملی متعلق به شخص دیگری است");

            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }
        public void AddInventory(SellerInvetory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است.");

            Inventories.Add(inventory);
        }
        public void EditInventory(long inventoryId,int count ,int price, int disCountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            //TODO Check Inventories
            currentInventory.Edit(count, price, disCountPercentage);
        }
        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }
}
