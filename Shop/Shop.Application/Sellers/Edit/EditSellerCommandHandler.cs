using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        public readonly ISellerRepository _repository;
        public readonly ISellerDomainService _domainService;

        public EditSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller =await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();
            seller.Edit(request.ShopName, request.NationalCode,request.Status,_domainService);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
