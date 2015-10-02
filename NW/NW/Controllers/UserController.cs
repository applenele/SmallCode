using NW.BLL;
using NW.Entity;
using NW.Entity.DataModels;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Login(string Username, string Password)
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
                model.Data = user;
                model.Statu = "ok";
            }
            return Json(model);
        }
    }
}