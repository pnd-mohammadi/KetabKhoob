using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Inventories.GetById;

namespace Shop.Query.Sellers.Inventories.GetByProductId
{
    public class GetSellerInventoryByProductIdQueryHandler : IQueryHandler<GetSellerInventoryByProductIdQuery, List<InventoryDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetSellerInventoryByProductIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public  async Task<List<InventoryDto>> Handle(GetSellerInventoryByProductIdQuery request, CancellationToken cancellationToken)
        {

            using var connection = _dapperContext.CreateConnection();
            var sql = @$"SELECT i.Id, i.SellerId , i.ProductId ,i.Count , i.Price,i.CreationDate , i.DiscountPercentage , s.ShopName ,
                        p.Title as ProductTitle,p.ImageName as ProductImage
            FROM {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId=s.Id  
            inner join {_dapperContext.Products} p on i.ProductId=p.Id WHERE ProductId=@productId";
            var result = await connection.QueryAsync<InventoryDto>(sql, new { productId = request.ProductId });
            return result.ToList();
        }        
    }
}

