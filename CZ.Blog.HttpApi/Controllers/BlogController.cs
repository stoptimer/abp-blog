using CZ.Blog.Application.Contracts;
using CZ.Blog.Application.IServices;
using CZ.Blog.HttpApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace CZ.Blog.HttpApi.Controllers
{
    /// <summary>
    /// 博客控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : AbpController
    {
        private readonly IBlogService _blogService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="blogService"></param>
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        /// <summary>
        /// 通过文章id获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ResponseResult<ArticleDto>> GetArticle(int id)
        {
            try
            {
                var article = await _blogService.GetArticle(id);
                return new ResponseResult<ArticleDto>(article);
            }
            catch (Exception ex)
            {
                return new ResponseResult<ArticleDto>(null, ex.Message);
            }



        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("{index}/{size}")]
        public async Task<ResponseResult<PageData<List<ArticleDto>>>> GetArticles(int index, int size)
        {
            PageData<List<ArticleDto>> pageData = new PageData<List<ArticleDto>>();
            var articles = await _blogService.GetArticles(index, size);
            pageData.PageNo = index;
            pageData.PageSize = size;
            pageData.TotalCount = articles.Total;
            pageData.List = articles.ArticleDtos;
            return new ResponseResult<PageData<List<ArticleDto>>>(pageData);

        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="request">请求实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult> SaveArticle(ArticleRequest request)
        {
            try
            {
                await _blogService.InsertArticleAsync(request);
            }
            catch (Exception ex)
            {
                new ResponseResult(ex);
            }

            return new ResponseResult("提交成功");

        }
        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="request">请求实体</param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<ResponseResult> UpdateArticle(ArticleRequest request)
        {
            await _blogService.UpdateArticleAsync(request.Id, request);
            return new ResponseResult("修改成功");

        }
    }
}
