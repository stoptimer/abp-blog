using System;
using Volo.Abp.Domain.Entities;
/// <summary>
/// 
/// </summary>
namespace CZ.Blog.Domain.Entity
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User:Entity<int>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime InputDate { get; set; }
    }


}
