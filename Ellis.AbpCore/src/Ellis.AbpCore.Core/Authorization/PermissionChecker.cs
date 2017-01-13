using Abp.Authorization;
using Ellis.AbpCore.Authorization.Roles;
using Ellis.AbpCore.MultiTenancy;
using Ellis.AbpCore.Users;

namespace Ellis.AbpCore.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
