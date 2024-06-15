using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Adrdreses.GetByList
{
    public class GetUserAddressByListQueryHandler : IQueryHandler<GetUserAddressByListQuery, List<AddressDto>>
    {
        private readonly DapperContext _dapperContext;

        public GetUserAddressByListQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<AddressDto>> Handle(GetUserAddressByListQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = "$ SELECT  * From {_dapperContext.UserAddresses } Where UserId=@userId ";
            var model =await connection.QueryAsync<AddressDto>(sql, new { userId = request.UserId });
            return model.ToList();
            

        }
    }
}
