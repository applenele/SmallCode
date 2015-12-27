using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NW.Utility;

namespace NW.Filter
{
    public class AutoSensitiveAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //filterContext.Result.;
            bool result = false;
            ViewResult v = filterContext.Result as ViewResult;
            object obj = v.Model;
            if (obj != null)
            {
                v.Model = WordFilterHelper<object>.TextFilter(v.Model, out result);
            }
            // v.Model
        }
    }
}