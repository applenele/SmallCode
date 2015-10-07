using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View(bllSession.IArticleBLL.GetList("").ToPagedList(1,10));
        }
    }
}