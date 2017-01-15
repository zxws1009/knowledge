using System.Reflection;
using Abp.Modules;
using Abp.Timing;
using Abp.Zero;
using Ellis.AbpCore.Localization;
using Abp.Zero.Configuration;
using Ellis.AbpCore.MultiTenancy;
using Ellis.AbpCore.Authorization.Roles;
using Ellis.AbpCore.Users;
using Ellis.AbpCore.Timing;

namespace Ellis.AbpCore
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpCoreCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //是否允许游客访问网站
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AbpCoreLocalizationConfigurer.Configure(Configuration.Localization);

            //是否允许多租户
            Configuration.MultiTenancy.IsEnabled = true;

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}