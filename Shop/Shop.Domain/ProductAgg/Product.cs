using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        private Product() {}
        public Product(string slug, string title, string imageName, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, IProductDomainService domainService, SeoData seoData)
        {
            Guard(slug, title, imageName, description, domainService);
            Slug = slug;
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            SeoData = seoData;
        }

        public string Slug { get; private set; }
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long? SecondarySubCategoryId { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }
        public SeoData SeoData { get; private set; }


        public void Edit(string slug, string title, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, SeoData seoData)
        {
            Slug = slug;
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            SeoData = seoData;
        }

        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public string RemoveImage(long imageId)
        {
            var image = Images.FirstOrDefault(f => f.Id == imageId);
            if (image == null)
                throw new NullOrEmptyDomainDataException("عکس یافت نشد");

            Images.Remove(image);
            return image.ImageName;
        }

        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);
            Specifications = specifications;
        }

        private void Guard(string slug, string title, string imageName, string description, IProductDomainService service)
        {
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            if (slug != Slug)
                if (service.IsSlugExist(slug))
                    throw new SlugIsDuplicateException();

        }
    }
}
