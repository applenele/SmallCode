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
        public ActionResult Index(int page = 1)
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
            article.Browses = article.Browses + 1;
            bllSession.IArticleBLL.Update(article);
            List<Reply> replies = new List<Entity.Reply>();
            replies = bllSession.IReplyBLL.GetList("").ToList();
            ViewBag.Replies = replies;
            return View(new vArticle(article));
        }

        [ValidateAntiForgeryToken]
        public ActionResult Reply(int id,string Description,int? FatherId)
        {
            if (CurrentUser == null)
            {
                return Redirect("/Shared/Info?msg=请先登录");
            }
            Reply reply = new Reply();
            reply.Time = DateTime.Now;
            reply.BlogId = id;
            reply.FatherId = FatherId;
            reply.UserId = CurrentUser.Id;
            reply.Description = Description;
            bllSession.IReplyBLL.Insert(reply);
            return Redirect("/Blog/Show/" + id);
        }
    }
}