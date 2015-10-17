using NW.Entity;
using NW.Entity.DataModels;
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
    public class CourseController : BaseController
    {
        /// <summary>
        ///  管理首页
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="Key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        // GET: Admin/Course
        public ActionResult Index(string Category, string Key, int page = 1)
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
            return View(bllSession.ICourseBLL.GetList(where).ToPagedList(page, 20));
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(string Category, string Title, string Lecturer, string Cover, string Description)
        {
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "数据填写错误！");
            }
            else
            {
                Course course = new Course();
                course.Title = Title;
                course.Category = Category;
                course.Lecturer = Lecturer;
                course.Description = Description;
                course.Cover = Cover;
                course.Time = DateTime.Now;
                course.Browses = 0;
                try
                {
                    bllSession.ICourseBLL.Insert(course);
                    return Redirect("/Admin/Course/Index");
                }
                catch
                {
                    log.Error(new LogContent("增加课程出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                    ModelState.AddModelError("", "增加出现异常");
                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            Course course = new Course();
            course = bllSession.ICourseBLL.GetEntity(id);
            return View(course);
        }
    }
}