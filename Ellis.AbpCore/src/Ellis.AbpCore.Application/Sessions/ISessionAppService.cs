using System.Threading.Tasks;
using Abp.Application.Services;
using Ellis.AbpCore.Sessions.Dto;

namespace Ellis.AbpCore.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
