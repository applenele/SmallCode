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

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.ILogBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                log.Error(new LogContent("删除图片出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                return Content("err");
            }
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            Log log = new Log();
            log = bllSession.ILogBLL.GetEntity(id);
            return View(log);
        }
    }
}