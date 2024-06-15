using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage :BaseEntity
    {
        public ProductImage(string imageName, int sequence)
        {
            Guard(imageName);
            ImageName = imageName;
            Sequence = sequence;
        }

        public long ProductId { get;internal set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }
        public void Guard(string ImageName)
        {
            NullOrEmptyDomainDataException.CheckString(ImageName, nameof(ImageName));
        }

    }
}
