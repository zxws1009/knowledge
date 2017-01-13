using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace Ellis.AbpCore.Web.Controllers
{
    public abstract class AbpCoreControllerBase: AbpController
    {
        protected AbpCoreControllerBase()
        {
            LocalizationSourceName = AbpCoreConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}