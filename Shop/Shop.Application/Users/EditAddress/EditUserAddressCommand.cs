using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommand:IBaseCommand
    {
        public EditUserAddressCommand( string name, string family, string shire, string city,
            string postalCode, string postalAddress, PhoneNumber? phoneNumber, string? nationalCode , long userId, long id)
        {
           
            Name = name;
            Family = family;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            UserId= userId;
            Id = id;
        }

        public long UserId { get;  set; }
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber ? PhoneNumber { get; private set; }
        public string ? NationalCode { get; private set; }
    }
  
}
