using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NW.Controllers;
using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;

namespace NW
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["OnLineUserCount"] = 0;

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            WordFilterHelper<object>.LoadSensitiveWords();
        }

        /// <summary>
        ///  捕获异常 记录日志 跳转到相应页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            log4net.ILog log = log4net.LogManager.GetLogger("myLogger");
            log.Error(new LogContent("Global record:" + Request.Url + lastError.Message, LogType.异常.ToString(), HttpHelper.GetIPAddress()));

            Exception exception = Server.GetLastError();
            var httpException = exception as HttpException ?? new HttpException(500, "服务器内部错误", exception);

            Response.Clear();

            var routeData = new RouteData();
            routeData.Values.Add("area", "");
            routeData.Values.Add("controller", "BaseController");
            routeData.Values.Add("fromAppErrorEvent", true);
            int HttpCode = httpException.GetHttpCode();
            string action = "";
            switch (HttpCode)
            {
                case 404:
                    action = "NotFound";
                    break;

                case 500:
                    action = "Error";
                    break;

                default:
                    action = "Error";
                    break;
            }

            routeData.Values.Add("action", action);
            routeData.Values.Add("httpStatusCode", HttpCode.ToString());
            Server.ClearError();

            IController controller = new BaseController();
            HttpContextWrapper httpContext = new HttpContextWrapper(Context);
            httpContext.Response.ContentType = "text/html";
            controller.Execute(new RequestContext(httpContext,routeData)); //执行构造的访问
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnLineUserCount"] = Convert.ToInt32(Application["OnLineUserCount"]) + 1;
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnLineUserCount"] = Convert.ToInt32(Application["OnLineUserCount"]) - 1;
            Application.UnLock();
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Response.End();
            // Response.StatusCode = 404;
            // Response.SuppressContent = true;
            // Context.ApplicationInstance.CompleteRequest();
        }
    }
}
