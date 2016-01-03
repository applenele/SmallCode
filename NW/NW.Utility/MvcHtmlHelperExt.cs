using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class MvcHtmlHelperExt
    {
        public static MvcHtmlString Sanitized<TModel>(this HtmlHelper<TModel> self, string html)
        {
            if (html == null) return new MvcHtmlString("");
            return new MvcHtmlString(HtmlFilter.Instance.SanitizeHtml(html));
        }

        public static MvcHtmlString CleanHtml<TModel>(this HtmlHelper<TModel> self, string html)
        {
            if (html == null) return new MvcHtmlString("");
            return new MvcHtmlString(NW.Utility.StringHelper.CleanHTML(html));
        }

        public static MvcHtmlString AntiForgerySID<TModel>(this HtmlHelper<TModel> self)
        {
            return new MvcHtmlString("<input type=\"hidden\" name=\"sid\" value=\"" + self.ViewBag.SID + "\" />");
        }

    }
}
