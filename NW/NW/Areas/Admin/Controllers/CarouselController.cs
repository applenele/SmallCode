using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NW.Filter;
using PagedList;
using NW.Entity;

namespace NW.Areas.Admin.Controllers
{
    public class CarouselController : BaseController
    {
        // GET: Admin/Carousel  
        /// <summary>
        /// 轮播管理首页
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(string Key, int page = 1)
        {
            string whereStr = "";
            if (!string.IsNullOrEmpty(Key))
            {
                whereStr += whereStr + " Name like  '%" + Key + "%' ";
            }
            return View(bllSession.ICarouselBLL.GetList(whereStr).ToPagedList(page, 20));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 增加 轮播
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AutoLog]
        [HttpPost]
        public ActionResult Add(Carousel model)
        {
            model.CreateBy = CurrentUser.Id;
            model.CreateDate = DateTime.Now;
            bllSession.ICarouselBLL.Insert(model);
            return Redirect("/Admin/Carousel/Index");
        }

        /// <summary>
        /// 删除轮播
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AutoLog]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bllSession.ICarouselBLL.Delete(id);
            return Content("ok");
        }
    }
}