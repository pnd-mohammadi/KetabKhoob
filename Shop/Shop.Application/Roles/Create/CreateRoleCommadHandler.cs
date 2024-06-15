using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommadHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommadHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions=new List<RolePermission>();
            request.permission.ForEach(f => { permissions.Add(new RolePermission(f)); });
            var role=new Role(request.Title, permissions);
            _repository.Add(role);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
