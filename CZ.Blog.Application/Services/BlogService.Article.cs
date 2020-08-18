using CZ.Blog.Application.Contracts;
using CZ.Blog.Domain.Entity;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CZ.Blog.Application.Services
{
    public partial class BlogService
    {
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async ValueTask<int> InsertArticleAsync(ArticleDto input)
        {
            var article = new Article()
            {
                CategoryId = input.CategoryId,
                Content = input.Content,
                Deleted = 0,
                Mdcontent = input.Mdcontent,
                Title = input.Title,
                UserId = 1,
                InputDate = DateTime.Now,
                LastDate = DateTime.Now
            };
            article = await _articleRepository.InsertAsync(article);
            return article.Id;
        }
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async ValueTask<bool> UpdateArticleAsync(int id, ArticleDto input)
        {
            var article = await _articleRepository.GetAsync(id);
            if (article == null)
                return false;
            article.CategoryId = input.CategoryId;
            article.Content = input.Content;
            article.Mdcontent = input.Mdcontent;
            article.LastDate = DateTime.Now;
            article = await _articleRepository.UpdateAsync(article);
            return true;
        }
        /// <summary>
        /// 获取单个文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async ValueTask<ArticleDto> GetArticle(int id)
        {
            var article = await _articleRepository.GetAsync(id);
            ArticleDto articleDTO = ObjectMapper.Map<Article, ArticleDto>(article);
            var category = await _categoryRepository.GetAsync(article.CategoryId);
            var tags = _tagRepository.WhereIf(true, x => x.Aid == article.Id);
            articleDTO.Category = category;
            articleDTO.Tags = tags.ToList();
            return articleDTO;
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async ValueTask<ArticleByPageDto> GetArticles(int index, int size)
        {
            ArticleByPageDto articleByPageDto = new ArticleByPageDto();
            articleByPageDto.Total = await _articleRepository.GetCountAsync();
            await _articleRepository.GetArticles(index, size);
            var articles = await _articleRepository.GetArticles(index, size);
            List<ArticleDto> articleDTOs = ObjectMapper.Map<List<Article>, List<ArticleDto>>(articles);
            articleByPageDto.ArticleDtos = articleDTOs;
            return articleByPageDto;
        }
    }
}
