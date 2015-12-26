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
using NW.Filter;

namespace NW.Areas.Admin.Controllers
{
    public class LogController : BaseController
    {
        // GET: Admin/Log
        public ActionResult Index(string Type, string Key, int page = 1)
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
            return View(bllSession.ILogBLL.GetList(where).ToPagedList(page, 20));
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "删除日志")]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.ILogBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
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

        /// <summary>
        /// 日志批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "批量删除日志")]
        public ContentResult MutiDelete(string ids)
        {
            try
            {
                string[] idsStrArr = ids.Split(',');
                foreach (var id in idsStrArr)
                {
                    bllSession.ILogBLL.Delete(Convert.ToInt32(id));
                }
                return Content("ok");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}