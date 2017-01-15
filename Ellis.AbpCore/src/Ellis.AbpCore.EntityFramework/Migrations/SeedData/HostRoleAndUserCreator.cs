using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Ellis.AbpCore.Authorization;
using Ellis.AbpCore.Authorization.Roles;
using Ellis.AbpCore.EntityFramework;
using Ellis.AbpCore.Users;
using Microsoft.AspNet.Identity;

namespace Ellis.AbpCore.Migrations.SeedData
{
    public class HostRoleAndUserCreator
    {
        private readonly AbpCoreDbContext _context;

        public HostRoleAndUserCreator(AbpCoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            //Admin role for host

            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.DisplayName, IsStatic = true });
                _context.SaveChanges();

                //Grant all tenant permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new AbpCoreAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                _context.SaveChanges();
            }

            //Admin user for tenancy host

            var adminUserForHost = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "hostadmin");
            if (adminUserForHost == null)
            {
                adminUserForHost = _context.Users.Add(
                    new User
                    {
                        UserName = "hostadmin",
                        Name = "HostAdmin",
                        Surname = "Administrator",
                        EmailAddress = "hostadmin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                    });

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));

                _context.SaveChanges();
            }
        }
    }
}