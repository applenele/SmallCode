using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class UserController : BaseController
    {

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            return Content("ok");
        }
    }
}