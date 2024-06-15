 using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
    {
        public readonly IUserRepository _repository;

        public ChangeUserPasswordCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user=await _repository.GetTracking(request.UserId);
            if (user == null) 
                return OperationResult.NotFound("کاربر یافت نشد");

            var currentPasswordHash= Sha256Hasher.Hash(request.CurrentPassword);
            if (user.Password != currentPasswordHash)
                return OperationResult.Error("error password");
            var newPassWordHash = Sha256Hasher.Hash(request.Password);
            user.ChangePassword(newPassWordHash);

            await _repository.Save();
            return OperationResult.Success();
        }
    }
    
}
