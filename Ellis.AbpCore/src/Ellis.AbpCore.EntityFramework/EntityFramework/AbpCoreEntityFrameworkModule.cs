using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace Ellis.AbpCore.EntityFramework
{
    [DependsOn(
        typeof(AbpCoreCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class AbpCoreEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AbpCoreDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}