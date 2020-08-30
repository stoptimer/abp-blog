using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CZ.Blog.Application.Contracts
{
    /// <summary>
    /// 文章分页实体
    /// </summary>
    public class ArticleByPageDto
    {
        /// <summary>
        /// 总数
        /// </summary>
        public long Total { get; set; }
        /// <summary>
        /// 文章集合
        /// </summary>
        public List<ArticleDto> ArticleDtos { get; set; }
    }
}
