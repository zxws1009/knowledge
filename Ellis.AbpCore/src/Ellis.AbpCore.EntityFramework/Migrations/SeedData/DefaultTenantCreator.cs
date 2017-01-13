using System.Linq;
using Ellis.AbpCore.EntityFramework;
using Ellis.AbpCore.MultiTenancy;

namespace Ellis.AbpCore.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly AbpCoreDbContext _context;

        public DefaultTenantCreator(AbpCoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
