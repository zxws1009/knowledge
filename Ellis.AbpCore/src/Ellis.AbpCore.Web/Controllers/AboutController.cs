using Microsoft.AspNetCore.Mvc;

namespace Ellis.AbpCore.Web.Controllers
{
    public class AboutController : AbpCoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}