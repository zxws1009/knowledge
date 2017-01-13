using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Ellis.AbpCore.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace Ellis.AbpCore.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AbpCore.EntityFramework.AbpCoreDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpCore";
        }

        protected override void Seed(AbpCore.EntityFramework.AbpCoreDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
