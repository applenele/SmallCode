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
            return View(bllSession.ICategoryBLL.GetList("").ToPagedList(1, 20));
        }
    }
}