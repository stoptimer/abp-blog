using System;
using Volo.Abp.Domain.Entities;
/// <summary>
/// 
/// </summary>
namespace CZ.Blog.Domain.Entity
{

    public class Category : Entity<int>
    {

        /// <summary>
        /// 分类名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime InputDate { get; set; }
    }


}
