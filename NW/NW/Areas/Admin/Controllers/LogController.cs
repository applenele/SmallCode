using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class LogController : BaseController
    {
        // GET: Admin/Log
        public ActionResult Index(string Type,string Key)
        {
            string where = "";
            if (!string.IsNullOrEmpty(Type))
            {
                where = where + "Type = '" + Type + "' ";
            }
            if (!string.IsNullOrEmpty(Key))
            {
                if (!string.IsNullOrEmpty(Type))
                {
                    where = where + " and ";
                }
                where = where + "Description LIKE '%" + Key + "%'";
            }
            return View(bllSession.ILogBLL.GetList(where).ToPagedList(1, 20));
        }
    }
}