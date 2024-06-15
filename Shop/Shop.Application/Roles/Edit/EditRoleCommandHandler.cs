using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        public readonly IRoleRepository _repository;
        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role =await _repository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();
            role.Edit(request.Title);
            var permissions = new List<RolePermission>();
            request.permission.ForEach(f=> 
            {
                permissions.Add(new RolePermission(f)); 
            });
            role.SetPermissions(permissions);
            await _repository.Save();
            return OperationResult.Success();
                    }
    }
}
