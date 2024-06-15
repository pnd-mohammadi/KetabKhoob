using Common.Domain;
using Common.Domain.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress :BaseEntity
    {
        private OrderAddress()  { }

        public OrderAddress(string name, string family, string shire, string city, string postalCode, 
            string postalAddress, string phoneNumber, string nationalCode)
        {
            Name = name;
            Family = family;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }

        public long OrderId { get; internal set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
    }
}
