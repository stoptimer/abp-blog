using CZ.Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CZ.Blog.EntityFrameworkCore
{
    [ConnectionStringName("MySql")]
    public class CZBlogDbContext : AbpDbContext<CZBlogDbContext>
    {
        public CZBlogDbContext(DbContextOptions<CZBlogDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigureCZBlog();

        }

        public DbSet<Article> article { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Tag> tag { get; set; }
        public DbSet<User> user { get; set; }
    }
}
