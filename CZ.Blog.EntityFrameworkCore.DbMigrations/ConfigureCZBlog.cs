using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace CZ.Blog.EntityFrameworkCore.DbMigrations
{
    public static class CZBlogDbContextModelCreatingExtensions
    {
        public static void ConfigureCZBlog(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
        }
    }
}
