using Abp.AspNetCore.Mvc.Authorization;
using Ellis.AbpCore.Authorization;
using Ellis.AbpCore.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace Ellis.AbpCore.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : AbpCoreControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}