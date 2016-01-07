using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NW.Pager
{
    public static class HtmlPageHelper
    {
        public static HtmlString PagedListPager(this HtmlHelper htmlHelper, int pageIndex, int totalPages)
        {
            var redirectTo = htmlHelper.ViewContext.RequestContext.HttpContext.Request.Url.AbsolutePath;

            var output = new StringBuilder();

            if (totalPages > 1)
            {
                if (pageIndex > 10)
                {
                    output.AppendFormat("<li><a href='{0}?page=1'>首页</a></li> ", redirectTo);
                }
                if (pageIndex > 1)
                {
                    //处理上一页的连接
                    output.AppendFormat("<li><a href='{0}?page={1}'>上一页</a></li> ", redirectTo, pageIndex - 1);
                }

                int start = ((pageIndex - 1) / 10) * 10;
                start = (pageIndex > totalPages ? 1 : start);
                int end = ((totalPages - start) >= 10 ? start + 10 : totalPages);
                for (int i = start + 1; i <= end; i++)
                {
                    output.AppendFormat("<li {0}><a href='{1}?page={2}'>{3}</a></li> ", (pageIndex == i ? "class='active'" : ""), redirectTo, i, i);
                }

                if (pageIndex < totalPages)
                {
                    //处理下一页的链接
                    output.AppendFormat("<li><a href='{0}?page={1}'>下一页</a></li> ", redirectTo, pageIndex + 1);
                }

                if ((pageIndex + 10) <= totalPages)
                {
                    output.AppendFormat("<li><a href='{0}?page={1}'>末页</a></li> ", redirectTo, totalPages);
                }
            }
            output.AppendFormat("<li><a>第{0}页 / 共{1}页</a></li>", pageIndex, totalPages);//这个统计加不加都行
            string outputString = string.Format("<div class='pagination-container'><ul class='pagination'>{0}</ul></div>", output.ToString());
            return new HtmlString(outputString);
        }
    }
}