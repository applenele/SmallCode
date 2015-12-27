using NW.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NW.Entity;

namespace NW.Areas.Admin.Controllers
{
    public class TestController : BaseController
    {
        [AutoLog(Description = "查看用户")]
        // GET: Admin/Test
        public ActionResult Index()
        {
            throw new Exception();
        }

        [AutoLog(Description = "删除用户")]
        public ActionResult Index2()
        {
            Article article = bllSession.IArticleBLL.GetEntity(3);
            return View(article);
        }
    }
}