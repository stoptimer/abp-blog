using CZ.Blog.Domain.Entity;
using CZ.Blog.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CZ.Blog.EntityFrameworkCore.Repositories
{
    public class TagRepository : EfCoreRepository<CZBlogDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<CZBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
