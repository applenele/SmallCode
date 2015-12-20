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
using System.Web.Security;

namespace NW.Controllers
{
    public class ForumController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            List<Topicforum> topicforums = new List<Topicforum>();
            List<Plateforum> plateforums = new List<Plateforum>();
            topicforums = bllSession.ITopicforumBLL.GetList("").ToList();
            plateforums = bllSession.IPlateforumBLL.GetList("").ToList();
            ViewBag.plateforums = plateforums;

            if (!Request.IsAuthenticated)
            {
                log.Info(new LogContent("游客访问了论坛", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent("游客访问了论坛", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View(bllSession.ITopicforumBLL.GetList("").ToPagedList(page, 10));
        }

        /// <summary>
        /// 主题显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Show(int id)
        {
            Topicforum topicforum = new Topicforum();
            topicforum = bllSession.ITopicforumBLL.GetEntity(id);
            topicforum.Browses = topicforum.Browses + 1;
            bllSession.ITopicforumBLL.Update(topicforum);

            if (!Request.IsAuthenticated)
            {
                log.Info(new LogContent("游客访问了帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户访问了帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View(topicforum);
        }

        /// <summary>
        /// 添加主题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            List<Plateforum> plateforum = new List<Plateforum>();
            plateforum = bllSession.IPlateforumBLL.GetList("").ToList();
            ViewBag.plateforumlist = plateforum;

            log.Info(new LogContent("用户访问发布主题页面", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View();
        }

        /// <summary>
        /// 添加主题
        /// </summary>
        /// <param name="title"></param>
        /// <param name="classify"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]  //允许特殊字符提交/
        public ActionResult Add(string title, int classify, string content)
        {
            try
            {
                Topicforum topicForum = new Topicforum();
                User user = new User();
                string userName = CurrentUser.Username;
                int userId = CurrentUser.Id;
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userId.ToString()))
                {
                    topicForum.Title = title;
                    topicForum.Content = content;
                    topicForum.Top = false;
                    topicForum.Time = DateTime.Now;
                    topicForum.LastReply = DateTime.Now;
                    topicForum.UserId = userId;
                    topicForum.Reward = 0;
                    topicForum.IsShow = true;
                    topicForum.IsClose = false;
                    topicForum.IsOfficeIdentified = false;
                    topicForum.PlateforumId = classify;
                    

                    bllSession.ITopicforumBLL.Insert(topicForum);
                    log.Info(new LogContent(userName + "用户发布了新的帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                }
            }
            catch
            {
                log.Error(new LogContent("用户发布主题出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                ModelState.AddModelError("", "用户发布主题出错！");
            }
            return RedirectToAction("Index","Forum");
        }

        /// <summary>
        /// 添加回复
        /// </summary>
        /// <param name="content"></param>
        /// <param name="cid"></param>
        /// <param name="id"></param>
        /// <param name="fatherID"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReplyAdd(string content, int cid, int id, int? fatherID)
        {
            if (!Request.IsAuthenticated)
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户回复了帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        /// 板块显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ForumShow(int id, int Time = 0, string Publish = "", int Rule = 0, int p = 0)
        {
            return View();
        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Sign()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户签到", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        /// 显示签到信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignInfo()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户查看了签到信息", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        ///举报 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult Report(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户举报", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ShowForumPicture(int id)
        {
            return View();
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CollectForum(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户添加了收藏", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CancelCollectForum(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户取消了收藏", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        /// 显示收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CollectShow(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string userName = CurrentUser.Username;
                log.Info(new LogContent(userName + "用户访问了收藏列表", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            return View();
        }

        /// <summary>
        /// 模块列表显示页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PlateList()
        {
            return View();
        }
    }
}