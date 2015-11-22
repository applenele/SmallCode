using NW.Entity;
using NW.Entity.ViewModels;
using NW.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class ForumController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}