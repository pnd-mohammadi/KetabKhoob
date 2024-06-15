using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug
{
    public class GetProductBySlugQueryHandler : IQueryHandler<GetProductBySlugQuery, ProductDto?>
    {
        private readonly ShopContext _contex;

        public GetProductBySlugQueryHandler(ShopContext contex)
        {
            _contex = contex;
        }

        public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken)
        {
            var product = await _contex.Products
                .FirstOrDefaultAsync(r => r.Slug == request.Slug, cancellationToken);
            var model = product.Map();
            if (product == null)
                return null;
            await model.SetCategories(_contex);
            return model;
        }
    }


}
