using System.Threading.Tasks;
using Abp.Application.Services;
using Ellis.AbpCore.Roles.Dto;

namespace Ellis.AbpCore.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
