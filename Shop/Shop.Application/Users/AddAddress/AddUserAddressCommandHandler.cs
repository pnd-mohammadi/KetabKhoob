using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
    {
        public readonly IUserRepository _repository;

        public AddUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user =await _repository.GetTracking(request.UserId);
            if (user == null) { }
            var userAddress = new UserAddress(request.Name, request.Family, true,request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.NationalCode);
            user.AddAddress(userAddress);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
