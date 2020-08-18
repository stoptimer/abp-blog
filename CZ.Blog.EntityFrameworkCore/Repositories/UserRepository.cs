using CZ.Blog.Domain.Entity;
using CZ.Blog.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CZ.Blog.EntityFrameworkCore.Repositories
{
    public class UserRepository : EfCoreRepository<CZBlogDbContext, User, int>, IUserRepository
    {
        public UserRepository(IDbContextProvider<CZBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
