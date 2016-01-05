using NW.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class EXArticleController : BaseController
    {
        // GET: Admin/EXArticle
        public ActionResult Index(int page = 1)
        {
            IEnumerable<EXArticle> articles = bllSession.IEXArticleBLL.GetListByPage(page,20,"");
            return View(articles.ToPagedList(page, 20));
        }

        public ActionResult TempIndex(int page = 1)
        {
            IEnumerable<EXArticleTemp> articleTemps = bllSession.IEXArticleTempBLL.GetListByPage(page, 20, "");
            return View(articleTemps.ToPagedList(page, 20));
        }
    }
}