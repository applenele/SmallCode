﻿using NW.Entity;
using NW.Entity.DataModels;
using NW.Entity.ViewModels;
using NW.Log4net;
using NW.Utility;
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
        public ActionResult Index(string Category, string Key,int page=1)
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
            List<Category> categories = bllSession.ICategoryBLL.GetList(where).ToList();
            ViewBag.Categories = categories;
            return View(bllSession.IArticleBLL.GetList(where).ToPagedList(page, 20));
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
        [ValidateInput(false)]
        public ActionResult Add(string Title, string Description, string Category)
        {
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
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
                    log.Error(new LogContent("增加博文出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
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
                log.Error(new LogContent("删除博文出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
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


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Article article = new Article();
            article = bllSession.IArticleBLL.GetEntity(id);
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            return View(article);
        }

        #region 修改博文
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Article model)
        {
            Article _article = new Article();
            _article = bllSession.IArticleBLL.GetEntity(model.Id);
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                try
                {
                    Article article = new Article();
                    article = bllSession.IArticleBLL.GetEntity(model.Id);
                    article.Category = model.Category;
                    article.Title = model.Title;
                    article.Description = model.Description;
                    bool result = bllSession.IArticleBLL.Update(article);
                    if (result)
                    {
                        return Redirect("/Admin/Blog/Show/" + model.Id);
                    }
                    else
                    {
                        log.Error(new LogContent(_article.Title +"修改博文出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                        ModelState.AddModelError("", "修改博文出错");
                    }
                }
                catch
                {
                    log.Error(new LogContent(_article.Title+"修改博文出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                    ModelState.AddModelError("", "修改博文出错");
                }
            }
            else
            {
                ModelState.AddModelError("", "填写数据有误");
            }
            return View(_article);
        } 
        #endregion
    }
}