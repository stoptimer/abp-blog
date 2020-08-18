using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace CZ.Blog.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
        typeof(CZBlogFrameworkCoreModule)
        )]
    public class CZBlogEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CZBlogMigrationsDbContext>();
        }
    }
}
