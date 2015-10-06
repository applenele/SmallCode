using NW.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string Key)
        {
            string where = "";
            if (!string.IsNullOrEmpty(Key))
            {
                where = where + "Description LIKE '%" + Key + "%'";
            }
            return View(bllSession.ICategoryBLL.GetList(where).ToPagedList(1, 20));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string Description)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                try
                {
                    category.Description = Description;
                    category.Time = DateTime.Now;
                    bllSession.ICategoryBLL.Insert(category);
                    return Redirect("/Admin/Category/Index");
                }
                catch
                {
                    ModelState.AddModelError("", "增加分类出错!");
                }
            }
            else
            {
                ModelState.AddModelError("", "你填写的信息有误!");
            }
            return View();
        }
    }
}