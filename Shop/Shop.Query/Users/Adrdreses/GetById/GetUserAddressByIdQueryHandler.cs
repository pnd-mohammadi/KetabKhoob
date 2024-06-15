using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Adrdreses.GetById
{
    public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT  top1 *  FROM {_dapperContext.UserAddresses}  Where id=@id";
            return await connection.QueryFirstOrDefaultAsync<AddressDto>(sql, new { id = request.AddressId });

        }
    }
}
