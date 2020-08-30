using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CZ.Blog.Application.Contracts
{
    /// <summary>
    /// 文章DTO
    /// </summary>
    public class ArticleDto
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// markdown内容
        /// </summary>
        public string Mdcontent { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public List<Tag> Tags { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int Deleted { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime InputDate { get; set; }
        /// <summary>
        /// 最后更改时间
        /// </summary>
        public DateTime LastDate { get; set; }
    }
}
