using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Ellis.AbpCore.Web.Views
{
    public abstract class AbpCoreRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpCoreRazorPage()
        {
            LocalizationSourceName = AbpCoreConsts.LocalizationSourceName;
        }
    }
}
