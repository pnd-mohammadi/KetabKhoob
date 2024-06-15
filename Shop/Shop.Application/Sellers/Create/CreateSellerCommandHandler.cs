using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        public readonly ISellerRepository _repository;
        public readonly ISellerDomainService _domainService;
        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _domainService);
            _repository.Add(seller);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
