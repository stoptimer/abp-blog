using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace CZ.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class CZBlogApplicationModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CZBlogApplicationModule>(validate: false);
                options.AddProfile<CZBlogAutoMapperProfile>(validate: false);
            });
        }
    }
}
