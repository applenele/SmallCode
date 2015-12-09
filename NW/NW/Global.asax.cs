using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;

namespace NW
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            log4net.ILog log = log4net.LogManager.GetLogger("myLogger");
            log.Error(new LogContent("Global record:" + Request.Url + lastError.Message, LogType.异常.ToString(), HttpHelper.GetIPAddress()));

            Response.StatusCode = 500;
            Server.ClearError();
        }
    }


}
