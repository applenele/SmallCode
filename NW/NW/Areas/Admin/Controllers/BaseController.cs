using NW.BLL;
using NW.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public readonly BLLSession bllSession = BLLSessionFactory.GetBLLSession();

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