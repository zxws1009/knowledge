using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Ellis.AbpCore.MultiTenancy;

namespace Ellis.AbpCore.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}