﻿using NW.BLL;
using NW.Entity;
using NW.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace NW.Controllers
{
    public class BaseController : Controller
    {
        public log4net.ILog log = log4net.LogManager.GetLogger("myLogger");

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
               CurrentUser = BLLSessionFactory.GetBLLSession().IUserBLL.GetUserByName(User.Identity.Name.Trim());
            }

            ViewBag.CurrentUser = CurrentUser;
        }


        public User CurrentUser { get; set; }

    }
}