using NW.BLL;
using NW.Entity;
using NW.IBLL;
using NW.Models;
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
    }
}