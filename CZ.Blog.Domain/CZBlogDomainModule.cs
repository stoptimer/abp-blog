using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace CZ.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule),typeof(AbpAuditLoggingDomainModule))]
    public class CZBlogDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabled = true; //Disables the auditing system
            });
        }
    }
}
