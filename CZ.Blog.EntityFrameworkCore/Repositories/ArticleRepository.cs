using CZ.Blog.Domain.Entity;
using CZ.Blog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CZ.Blog.EntityFrameworkCore.Repositories
{
    public class ArticleRepository : EfCoreRepository<CZBlogDbContext, Article, int>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<CZBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="index">当前页数</param>
        /// <param name="size">显示数量</param>
        /// <returns></returns>
        public async Task<List<Article>> GetArticles(int index, int size)
        {
            return await DbContext.article.OrderByDescending(x => x.InputDate).Skip((index - 1) * size).Take(size).ToListAsync();
        }
    }
}
