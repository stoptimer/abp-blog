using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CZ.Blog.Domain.Repositories
{
    public interface IArticleRepository : IRepository<Article, int>
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="index">当前页数</param>
        /// <param name="size">显示数量</param>
        /// <returns></returns>
        Task<List<Article>> GetArticles(int index, int size);
    }
}
