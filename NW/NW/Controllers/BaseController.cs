using NW.BLL;
using NW.Entity;
using NW.Entity.DataModels;
using NW.IBLL;
using NW.Log4net;
using NW.Models;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace NW.Controllers
{
    public class BaseController : Controller
    {
        public readonly BLLSession bllSession = BLLSessionFactory.GetBLLSession();
        public readonly log4net.ILog log = log4net.LogManager.GetLogger("myLogger");

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

        public ActionResult Message(string msg)
        {
            return Redirect("/Shared/Info?mag=" + msg);
        }


        // Copyright (c) Harbin Code Comb Technology Co., Ltd. All rights reserved.
        // These functions are refered to https://github.com/codecomb/extensions
        // Licensed under the Apache License, Version 2.0. See License in the project root for license information.
        [NonAction]
        [Obsolete]
        protected ActionResult Prompt(Prompt prompt)
        {
            Response.StatusCode = prompt.StatusCode;
            return View("Info", prompt);
        }

        [NonAction]
        protected ActionResult Prompt(Action<Prompt> setupPrompt)
        {
            Prompt prompt = new Prompt();
            setupPrompt(prompt);
            Response.StatusCode = prompt.StatusCode;
            return View("Info", prompt);
        }

        /// <summary>
        /// action 之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentUser != null)
            {
                log.Info(new LogContent(CurrentUser.Username + ":访问了" + Request.Url, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            else
            {
                log.Info(new LogContent("游客访问了" + Request.Url, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            log.Error(new LogContent(Request.Url + filterContext.Exception.Message, LogType.异常.ToString(), HttpHelper.GetIPAddress()));
            base.OnException(filterContext);
        }

        /// <summary>
        /// 未找到页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return Prompt(x =>
            {
                x.Title = "你访问的页面不存在！";
                x.Details = "你访问的页面不存在！";
                x.RedirectText = "返回首页！";
                x.RedirectUrl = "/Home/Index";
                x.StatusCode = 404;
            });
        }

        /// <summary>
        /// 访问你的页面出错
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return Prompt(x =>
            {
                x.Title = "出问题啦！";
                x.Details = "出问题啦！";
                x.RedirectText = "返回首页！";
                x.RedirectUrl = "/Home/Index";
                x.StatusCode = 500;
            });
        }
    }
}