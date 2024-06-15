using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        private Role() { }
        public Role(string title, List<RolePermission> permissions)
        {
            Title = title;
            Permissions = permissions;
        }

        public string Title { get; private set; }
        public List<RolePermission> Permissions { get; private set; }

        public void Edit(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            Title = title;
        }

        public void SetPermissions(List<RolePermission> permissioms) 
        {
            Permissions = permissioms; 
        }


    }

}
