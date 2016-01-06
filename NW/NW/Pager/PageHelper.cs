using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NW.Pager
{
    public static class PageHelper
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> superset, int pageIndex, int pageSize,int total)
        {
            PagedList<T> data = new PagedList<T>();
            if (total % pageSize == 0)
            {
                data.PageCount = total / pageSize;
            }
            else
            {
                data.PageCount = total / pageSize + 1;
            }
            data.PageIndex = pageIndex;
            data.PageSize = pageSize;
            data.Total = total;
            data.PageListData = superset;
            return data;
        }
    }
}