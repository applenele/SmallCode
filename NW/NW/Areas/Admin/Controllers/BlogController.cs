﻿using NW.Entity;
using NW.Entity.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogController : BaseController
    {
        // GET: Admin/Blog
        public ActionResult Index(string Category, string Key)
        {
            string where = "";
            if (!string.IsNullOrEmpty(Category))
            {
                where = where + "Category = '" + Category + "' ";
            }
            if (!string.IsNullOrEmpty(Key))
            {
                if (!string.IsNullOrEmpty(Category))
                {
                    where = where + " and ";
                }
                where = where + "Title LIKE '%" + Key + "%'";
            }
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            return View(bllSession.IArticleBLL.GetList(where).ToPagedList(1, 20));
        }

        #region 增加博文
        [HttpGet]
        public ActionResult Add()
        {
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            return View();
        }

        /// <summary>
        /// 增加博文
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(string Title, string Description, string Category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Article article = new Article();
                    article.Browses = 0;
                    article.Time = DateTime.Now;
                    article.Title = Title;
                    article.UserId = CurrentUser.Id;
                    article.Description = Description;
                    article.Category = Category;
                    bllSession.IArticleBLL.Insert(article);
                    return Redirect("/Admin/Blog/Index");
                }
                catch
                {
                    ModelState.AddModelError("", "增加出现异常");
                }
            }
            else
            {

            }
            return View();
        }
        #endregion

        /// <summary>
        /// 删除博文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.IArticleBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }

        /// <summary>
        /// 后台博文预览
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            Article article = new Article();
            article = bllSession.IArticleBLL.GetEntity(id);
            return View(new vArticle(article));
        }
    }
}