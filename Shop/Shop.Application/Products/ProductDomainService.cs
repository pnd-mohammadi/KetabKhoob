using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Service;

namespace Shop.Application.Products
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _repository;

        public ProductDomainService(IProductRepository repository)
        {
            _repository = repository;
        }

        public bool IsSlugExist(string slug)
        {
            return _repository.Exists(s => s.Slug == slug);
        }
    }
}
