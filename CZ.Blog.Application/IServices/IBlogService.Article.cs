using CZ.Blog.Application.Contracts;
using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CZ.Blog.Application.IServices
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ValueTask<int> InsertArticleAsync(ArticleDto input);
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ValueTask<bool> UpdateArticleAsync(int id, ArticleDto input);
        /// <summary>
        /// 获取单个文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<ArticleDto> GetArticle(int id);
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        ValueTask<ArticleByPageDto> GetArticles(int index, int size);
    }
}
