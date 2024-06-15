using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Service;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        private Category()
        {
            Childs = new List<Category>();
        }
        public Category(string slug, string title, SeoData seoData, ICategoryDomainService service)
        {
            slug = slug.ToSlug();
            Guard(slug,title, service);
            Slug = slug;
            Title = title;
            SeoData = seoData;
            Childs = new List<Category>();
        }

        public String Slug { get; private set; }
        public String Title { get; private set; }
        public SeoData SeoData { get; private set; }
        public long ? ParentId { get; private set; }
        public List<Category> Childs { get; private set; }

        public void Edit(string slug, string title, SeoData seoData, ICategoryDomainService service)
        {
            slug = slug.ToSlug();
            Guard(slug, title, service);
            Slug = slug;
            Title = title;
            SeoData = seoData;
        }

        public void AddChild(string slug, string title, ICategoryDomainService service)
        {
            Childs.Add(new Category(Slug, Title, SeoData , service)
            {
                ParentId = Id
            });
        }

        public void Guard(string slug, string title, ICategoryDomainService service)
        {
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

            if (slug != Slug)
                if (service.IsSlugExist(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}
