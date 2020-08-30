using CZ.Blog.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace CZ.Blog.HttpApi
{
    /// <summary>
    /// HttpApiModule
    /// </summary>
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(CZBlogApplicationModule)
        )]
    public class CZBlogHttpApiModule : AbpModule
    {
        
    }
}
