using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            log.Info(new LogContent("test", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View();
        }
    }
}