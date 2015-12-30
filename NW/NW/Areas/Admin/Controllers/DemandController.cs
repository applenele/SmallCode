using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NW.Entity;

namespace NW.Areas.Admin.Controllers
{
    public class DemandController : BaseController
    {
        // GET: Admin/Demand
        public ActionResult Index(string Key, int page = 1)
        {
            string whereStr = "";
            if (!string.IsNullOrEmpty(Key))
            {
                whereStr += " Title like '%" + Key + "%' ";
            }
            return View(bllSession.IDemandBLL.GetList(whereStr).ToPagedList(page, 20));
        }

        /// <summary>
        ///  删除约课
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.IDemandBLL.Delete(id);
                log.Info(new LogContent(CurrentUser.Username + ":删除约课" + id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Content("ok");
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + ":删除约课" + id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                return Content("err");
            }
        }

        /// <summary>
        /// 约课展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DemandShow(int id)
        {
            Demand model = bllSession.IDemandBLL.GetEntity(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Demand model = bllSession.IDemandBLL.GetEntity(id);
            return View(model);
        }

        /// <summary>
        /// 修改约课
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Demand model)
        {
            Demand obj = bllSession.IDemandBLL.GetEntity(model.Id);
            try
            {
                obj.State = model.State;
                bllSession.IDemandBLL.Update(obj);
                log.Info(new LogContent(CurrentUser.Username + ":修改约课" + model.Id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Redirect("/Admin/Demand/Index");
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + ":修改约课" + model.Id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
            }
            return View(obj);
        }

    }
}