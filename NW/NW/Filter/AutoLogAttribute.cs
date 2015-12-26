using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Filter
{
    public class AutoLogAttribute : FilterAttribute, IExceptionFilter, IResultFilter
    {
        public string Description { set; get; }

        private readonly log4net.ILog log = log4net.LogManager.GetLogger("myLogger");

        /// <summary>
        ///   action 异常记录
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            string user = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(user))
            {
                user = "匿名用户";
            }
            string url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            log.Error(new LogContent("action exception log record:" + user + "," + url + "," + Description, LogType.异常.ToString(), HttpHelper.GetIPAddress()),filterContext.Exception);
        }

        /// <summary>
        /// 加载视图之后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///  action执行之后 视图加载之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string user = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(user))
            {
                user = "匿名用户";
            }
            string url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            log.Info(new LogContent("action log record:" + user + "," + url + "," + Description, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
        }
    }
}