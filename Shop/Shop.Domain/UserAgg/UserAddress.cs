using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        private UserAddress() { }
        public UserAddress(string name, string family, bool activeAddreess, string shire, string city,
            string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
        {
            Name = name;
            Family = family;
            ActiveAddreess = false;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }

        public long UserId { get;internal set; }
        public string Name { get; private set; }
        public string Family { get; private set;  }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set;  }
        public string NationalCode { get; private set;  }
        public bool ActiveAddreess { get; private set; }

        public void Edit(string name, string family, string shire, string city,
            string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
        {
            Guard(name, family, shire,city, postalCode,postalAddress, phoneNumber, nationalCode);
            Name = name;
            Family = family;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
        public void Active() 
        {
            ActiveAddreess = true;
        }
        public void DeActive()
        {
            ActiveAddreess = false;
        }
        public void Guard(string name, string family,string shire, string city,string postalCode, string postalAddress,
            PhoneNumber phoneNumber, string nationalCode)
        {
            if (phoneNumber == null)
                throw new NullOrEmptyDomainDataException();

            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException(" code melli Not Valid");

        }
    }
}
