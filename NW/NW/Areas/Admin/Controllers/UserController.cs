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
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string Key, int page = 1)
        {
            string where = "";
            int onlineCount = (int)HttpContext.Application["OnLineUserCount"];
            if (!string.IsNullOrEmpty(Key))
            {
                where = where + "Username LIKE '%" + Key + "%'";
            }
            ViewBag.OnlineCount = onlineCount;
            return View(bllSession.IUserBLL.GetList(where).ToPagedList(page, 20));
        }

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.IUserBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                log.Error(new LogContent("删除用户出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                return Content("err");
            }
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = new Entity.User();
            user = bllSession.IUserBLL.GetEntity(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            try
            {
                User user = bllSession.IUserBLL.GetEntity(model.Id);
                user.Username = model.Username;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.Photo = model.Photo;
                user.QQ = model.QQ;
                bllSession.IUserBLL.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                log.Error(new LogContent("修改用户出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                return View(model);
            }
        }
    }
}