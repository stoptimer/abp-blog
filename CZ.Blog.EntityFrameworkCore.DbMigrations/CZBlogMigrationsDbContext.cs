using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CZ.Blog.EntityFrameworkCore.DbMigrations
{
    public class CZBlogMigrationsDbContext : AbpDbContext<CZBlogMigrationsDbContext>
    {
        public CZBlogMigrationsDbContext(DbContextOptions<CZBlogMigrationsDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

          
           
            builder.ConfigureAuditLogging();
        
         

            /* Configure your own tables/entities inside the ConfigureBookStore method */

            builder.ConfigureCZBlog();
        }
    }
}
