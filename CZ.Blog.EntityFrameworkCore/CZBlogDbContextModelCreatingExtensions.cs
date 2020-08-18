using CZ.Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace CZ.Blog.EntityFrameworkCore
{
    public static class CZBlogDbContextModelCreatingExtensions
    {
        public static void ConfigureCZBlog(this ModelBuilder modelBuilder)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));
            modelBuilder.Entity<Article>(b =>
            {
                b.ToTable("article");

                b.Property(x => x.Title).IsRequired();
                b.Property(x => x.Mdcontent).IsRequired();
                b.Property(x => x.Deleted).HasDefaultValue(false);

                b.HasIndex(q => q.Id);
            });
        }
    }
}
