using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NW.Pager
{
    public class PagedList<T>
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total { set; get; }

        public IEnumerable<T> PageListData { set; get; }
    }
}