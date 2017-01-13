using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ellis.AbpCore.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpCoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}