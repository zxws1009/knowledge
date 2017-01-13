using Ellis.AbpCore.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Ellis.AbpCore.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly AbpCoreDbContext _context;

        public InitialHostDbBuilder(AbpCoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
