using System;
using Volo.Abp.Domain.Entities;
/// <summary>
/// 
/// </summary>
namespace CZ.Blog.Domain.Entity
{

    public class Tag : Entity<int>
    {

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文章id
        /// </summary>
        public int Aid { get; set; }
       
        /// <summary>
        /// 删除状态
        /// </summary>
        public int Deleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created { get; set; }
    }


}
