using NW.BLL;
using NW.Entity;
using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
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
                log.Info(new LogContent(Username + ":登陆", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return Json(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(string email)
        {
            if (RegexHelper.IsEmail(email))
            {
                if (bllSession.IUserBLL.GetUserByEmail(email) != null)
                {
                    return Prompt(x =>
                    {
                        x.Details = "该邮箱已经存在！";
                        x.Title = "注册失败！";
                        x.RedirectText = "返回重新注册！";
                        x.RedirectUrl = "/User/Register";
                    });
                }
                else
                {
                    return SendMail(email);
                }
            }
            else
            {
                return Prompt(x =>
                {
                    x.Details = "邮箱格式不正确！";
                    x.Title = "注册失败！";
                    x.RedirectText = "返回重新注册！";
                    x.RedirectUrl = "/User/Register";
                });
            }
        }

        [HttpGet]
        public ActionResult RegisterDetail(string email)
        {
            ViewBag.Email = email;
            if (bllSession.IUserBLL.GetUserByEmail(email) != null)
            {
                return Prompt(x =>
                {
                    x.Details = "该邮箱已经存在！";
                    x.Title = "注册失败！";
                    x.RedirectText = "返回重新注册！";
                    x.RedirectUrl = "/User/Register";
                });
            }
            else
            {
                return View("RegisterDetail");
            }
        }

        [HttpPost]
        public ActionResult RegisterDetail(string Username, string Password, string Email)
        {
            AjaxModel model = new AjaxModel();
            User user = new Entity.User();
            try
            {
                if (bllSession.IUserBLL.GetUserByEmail(Email) != null)
                {
                    model.Statu = "err";
                    model.Msg = "该邮箱已经存在！";
                }
                else
                {
                    IBLL.IUserBLL bll = BLLSessionFactory.GetBLLSession().IUserBLL;
                    user = bll.GetUserByName(Username);
                    if (user != null)
                    {
                        model.Statu = "err";
                        model.Msg = "该用户名已经存在！";
                    }
                    else
                    {
                        user = new Entity.User();
                        user.Username = Username.Trim();
                        user.Password = Encryt.GetMD5(Password.Trim());
                        user.Time = DateTime.Now;
                        user.Email = Email;
                        bll.Insert(user);
                        model.Statu = "ok";
                        model.Msg = "注册用户成功！";
                    }
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

        [HttpGet]
        public ActionResult Show(int id)
        {
            User user = new Entity.User();
            user = bllSession.IUserBLL.GetEntity(id);
            return View(user);
        }

        public ActionResult SendMail(string email)
        {
            WebMail.SmtpServer = ConfigurationHelper.GetValue("SmtpServer");//获取或设置要用于发送电子邮件的 SMTP 中继邮件服务器的名称。
            WebMail.SmtpPort = Int32.Parse(ConfigurationHelper.GetValue("SmtpPort"));//发送端口
            WebMail.EnableSsl = true;//是否启用 SSL GMAIL 需要 而其他都不需要 具体看你在邮箱中的配置
            WebMail.UserName = ConfigurationHelper.GetValue("UserName");//账号名
            WebMail.From = ConfigurationHelper.GetValue("From"); //邮箱名
            WebMail.Password = ConfigurationHelper.GetValue("Password");//密码
            WebMail.SmtpUseDefaultCredentials = true;//是否使用默认配置

            WebMail.Send(to: email,
                         subject: "注册验证信息",
                         body: Utility.String.EmailHtml(email));
            return Prompt(x =>
            {
                x.Title = "注册通知！";
                x.Details = "已向您的邮箱：" + email + "发送验证信息，请查看完成注册！";
                x.RedirectText = "返回首页";
                x.RedirectUrl = "/Home/Index";
            });
        }

        public ActionResult EmailVerify(string encryt)
        {
            string email = Utility.Encryt.AESDecrypt(encryt);
            if (RegexHelper.IsEmail(email))
            {
                return RegisterDetail(email);
            }
            else
            {
                return Prompt(x =>
                {
                    x.Details = "验证邮箱失败！";
                    x.Title = "注册失败！";
                    x.RedirectText = "返回重新注册！";
                    x.RedirectUrl = "/User/Register";
                });
            }
        }

        public ActionResult Test()
        {
            string SmtpServer = ConfigurationHelper.GetValue("SmtpServer");
            ViewBag.SmtpServer = SmtpServer;
            return View();
        }

        #region 修改用户信息
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(CurrentUser);
        }

        public ActionResult Edit(User model, HttpPostedFileBase file)
        {
            try
            {
                User user = new Entity.User();
                user = bllSession.IUserBLL.GetEntity(model.Id);
                if (file != null)
                {
                    string random = DateHelper.GetTimeStamp();
                    string root = "~/UserPhoto/";
                    var phicyPath = HostingEnvironment.MapPath(root);
                    if (!Directory.Exists(phicyPath))
                    {
                        Directory.CreateDirectory(phicyPath);
                    }
                    file.SaveAs(phicyPath + random + Path.GetExtension(file.FileName));
                    user.Photo = "/UserPhoto/" + random + Path.GetExtension(file.FileName);
                }
                user.Phone = model.Phone;
                user.QQ = model.QQ;
                user.Remark = model.Remark;
                user.Program = model.Program;
                user.Address = model.Address;

                bllSession.IUserBLL.Update(user);
                log.Info(new LogContent(model.Username + "用户修改了资料", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Redirect("/User/Show/" + model.Id);
            }
            catch
            {
                log.Error(new LogContent("用户修改资料出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                ModelState.AddModelError("", "用户修改资料出错！");
            }
            return View();
        }

        #endregion
    }
}