using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Ellis.AbpCore.Configuration;
using Ellis.AbpCore.EntityFramework;

namespace Ellis.AbpCore.Migrator
{
    [DependsOn(typeof(AbpCoreEntityFrameworkModule))]
    public class AbpCoreMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(AbpCoreMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<AbpCoreDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpCoreConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}