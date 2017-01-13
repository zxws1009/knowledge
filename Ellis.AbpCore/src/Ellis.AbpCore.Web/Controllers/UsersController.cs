using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Ellis.AbpCore.Authorization;
using Ellis.AbpCore.Users;
using Microsoft.AspNetCore.Mvc;

namespace Ellis.AbpCore.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : AbpCoreControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}