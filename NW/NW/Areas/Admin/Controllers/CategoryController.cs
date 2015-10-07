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

        #region 增加分类
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
                    log.Error(new LogContent("增加分类出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                    ModelState.AddModelError("", "增加分类出错!");
                }
            }
            else
            {
                ModelState.AddModelError("", "你填写的信息有误!");
            }
            return View();
        } 
        #endregion


        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.ICategoryBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                log.Error(new LogContent("删除分类出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                return Content("err");
            }
        }

      
    }
}