using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ellis.AbpCore.Configuration;

namespace Ellis.AbpCore.Web.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }
    }
}