using CZ.Blog.Application;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace CZ.Blog.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(CZBlogApplicationModule)
        )]
    public class CZBlogHttpApiModule:AbpModule
    {
    }
}
