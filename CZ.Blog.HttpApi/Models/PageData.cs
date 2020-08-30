using System;
using System.Collections.Generic;
using System.Text;

namespace CZ.Blog.HttpApi.Models
{
    /// <summary>
    /// 分页通用实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageData<T>
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        /// 当前数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public long TotalCount { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T List { get; set; }
    }
}
