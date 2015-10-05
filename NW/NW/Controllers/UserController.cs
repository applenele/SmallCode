using NW.BLL;
using NW.Entity;
using NW.Entity.DataModels;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NW.Controllers
{
    public class UserController : BaseController
    {

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string Username, string Password, string ReturnUrl)
        {
            AjaxModel model = new AjaxModel();
            IBLL.IUserBLL bll = BLLSessionFactory.GetBLLSession().IUserBLL;
            User user = new User();
            Password = Encryt.GetMD5(Password.Trim());
            user = bll.Login(Username.Trim(), Password);
            if (user == null)
            {
                model.Data = user;
                model.Msg = "用户名或者密码不正确！";
                model.Statu = "err";
            }
            else
            {
                FormsAuthentication.SetAuthCookie(Username.Trim(), false);
                model.Data = user;
                model.Statu = "ok";
                model.BackUrl = ReturnUrl == null ? "/Home/Index" : ReturnUrl;
            }
            return Json(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Username, string Password)
        {
            AjaxModel model = new AjaxModel();
            User user = new Entity.User();
            try
            {
                IBLL.IUserBLL bll = BLLSessionFactory.GetBLLSession().IUserBLL;
                user = bll.GetUserByName(Username);
                if (user != null)
                {
                    model.Statu = "err";
                    model.Msg = "改用户名已经存在！";
                }
                else
                {
                    user = new Entity.User();
                    user.Username = Username.Trim();
                    user.Password = Encryt.GetMD5(Password.Trim());
                    user.Time = DateTime.Now;
                    bll.Insert(user);
                    model.Statu = "ok";
                    model.Msg = "注册用户成功！";
                }
            }
            catch
            {
                model.Statu = "err";
                model.Msg = "注册用户出错请重试！";
            }
            return Json(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}