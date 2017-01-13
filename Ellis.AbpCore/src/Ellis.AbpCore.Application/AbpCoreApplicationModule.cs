using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Ellis.AbpCore.Authorization;

namespace Ellis.AbpCore
{
    [DependsOn(
        typeof(AbpCoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpCoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpCoreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}