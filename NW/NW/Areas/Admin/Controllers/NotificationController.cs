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
    public class NotificationController : BaseController
    {
        // GET: Admin/Notification
        public ActionResult Index(string Key, int page = 1)
        {
            string where = "";
            if (!string.IsNullOrEmpty(Key))
            {
                where = where + "Description LIKE '%" + Key + "%'";
            }
            return View(bllSession.INotificationBLL.GetList(where).ToPagedList(page, 20));
        }

        #region 增加通告
        /// <summary>
        /// 增加通告
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 增加通告
        /// </summary>
        /// <param name="Description"></param>
        /// <param name="Priority"></param>
        /// <param name="IsShow"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string Description, int? Priority, bool IsShow)
        {
            try
            {
                Notification notification = new Notification();
                if (!Priority.HasValue)
                {
                    notification.Priority = 0;
                }
                else
                {
                    notification.Priority = (int)Priority;
                }
                notification.Description = Description;
                notification.IsShow = IsShow;
                notification.CreatedTime = DateTime.Now;
                bllSession.INotificationBLL.Insert(notification);
                return Redirect("/Admin/Notification/Index");
            }
            catch
            {
                log.Error(new LogContent("增加通告失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                ModelState.AddModelError("", "增加通告失败");
            }
            return View();
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.INotificationBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                log.Error(new LogContent("删除通告出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                return Content("err");
            }
        }

        #region 修改通告
        /// <summary>
        /// 修改通告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Notification notification = new Notification();
            notification = bllSession.INotificationBLL.GetEntity(id);
            return View(notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Notification model)
        {
            try
            {
                Notification notification = new Notification();
                notification = bllSession.INotificationBLL.GetEntity(model.Id);
                if (notification != null)
                {
                    notification.Description = model.Description;
                    notification.Priority = model.Priority;
                    notification.IsShow = model.IsShow;

                    bllSession.INotificationBLL.Update(notification);
                    return Redirect("/Admin/Notification/Index");
                }
            }
            catch
            {
                log.Error(new LogContent("修改通告失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                ModelState.AddModelError("", "修改通告失败");
            }
            return View();
        }
        #endregion

    }
}