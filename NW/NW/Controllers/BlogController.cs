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
        public ActionResult Index(int page = 1, string Category = "", string Date = "")
        {
            bool result = false;
            string attachUrl = "";
            List<vArticle> articles = new List<vArticle>();
            string whereStr = "";
            if (!string.IsNullOrEmpty(Category))
            {
                attachUrl = "Category = " + Category;
                whereStr = whereStr + "Category = '" + Category + "'";
            }
            if (!string.IsNullOrEmpty(Date))
            {
                attachUrl = "Date = " + Date;
                whereStr = whereStr + " DATE_FORMAT(a.Time,'%Y-%m') = '" + Date + "'";
            }
            var query = bllSession.IArticleBLL.GetList(whereStr);
            int totalCount = 0;
            PagerHelper.DoPage(ref query, page, 20, ref totalCount);
            foreach (var item in query.ToTextFilter(out result))
            {
                articles.Add(new vArticle(item));
            }
            var articleAsIPagedList = new StaticPagedList<vArticle>(articles, page, 20, totalCount).ToTextFilter(out result);
            List<SideArticleCategory> Categories = SideHelper.GetSideCategoryCategories();
            List<SideArticleCalendar> Calendars = SideHelper.GetSideArticleCalendars();
            ViewBag.Categories = Categories;
            ViewBag.Calendars = Calendars;
            ViewBag.AttachUrl = attachUrl;
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
            replies = bllSession.IReplyBLL.GetList("r.BlogId = " + id).ToList();
            ViewBag.Replies = replies;
            bool result = false;
            //vArticle _article = WordFilterHelper<vArticle>.TextFilter(new vArticle(article), out result) as vArticle;
            return View(new vArticle(article).ToTextFilter(out result));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Reply(int id, string Description, int? FatherId)
        {
            if (CurrentUser == null)
            {
                return Prompt(x =>
                {
                    x.Title = "请先登录";
                    x.RedirectText = "返回上一页";
                    x.Details = "返回上一页";
                    x.RedirectUrl = "/Blog/Show/" + id;
                });
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