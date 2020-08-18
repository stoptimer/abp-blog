using CZ.Blog.Domain.Entity;
using CZ.Blog.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CZ.Blog.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfCoreRepository<CZBlogDbContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<CZBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
