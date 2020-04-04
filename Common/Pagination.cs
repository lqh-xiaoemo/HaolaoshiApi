using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pagination<T>
    {
        public static Pagination<T> Init(int PageCount, int Total, IEnumerable<T> Items)
        {
            return new Pagination<T>() { PageCount = PageCount, Total = Total, Items = Items };
        }
        public IEnumerable<T> Items { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 总记录数量
        /// </summary>
        public int Total { get; set; }

    }
}
