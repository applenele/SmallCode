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
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index(int page=1)
        {
            List<vArticle> articles = new List<vArticle>();
            var query = bllSession.IArticleBLL.GetList("");
            int totalCount = 0;
            PagerHelper.DoPage(ref query, page, 10, ref totalCount);
            foreach (var item in query)
            {
                articles.Add(new vArticle(item));
            }
            var articleAsIPagedList = new StaticPagedList<vArticle>(articles, page, 20, totalCount);
            return View(articleAsIPagedList);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var article = new Article();
            article = bllSession.IArticleBLL.GetEntity(id);
            return View(new vArticle(article));
        }
    }
}