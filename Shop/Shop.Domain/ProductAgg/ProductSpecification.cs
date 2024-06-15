using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductSpecification : BaseEntity
    {
        public ProductSpecification(string key, string value)
        {
            Guard(key, value);
            Key = key;
            Value = value;
        }

        public long ProductId { get; internal set; }
        public string Key{ get; private set; }
        public string Value { get; private set; }

        public void Guard(string Key, string Value)
        {
            NullOrEmptyDomainDataException.CheckString(Key, nameof(Key));
            NullOrEmptyDomainDataException.CheckString(Value, nameof(Value));
        }

    }
}
