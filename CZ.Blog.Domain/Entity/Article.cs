using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace CZ.Blog.Domain.Entity
{
    [Audited]
    public class Article : Entity<int>
    {
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
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }
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
