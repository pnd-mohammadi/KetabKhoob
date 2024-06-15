using Common.Domain.ValueObjects;
using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.DTOs
{
    public class AddressDto : BaseDto
    {
        public long UserId { get; internal set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAddreess { get; private set; }
    }
}
