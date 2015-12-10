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
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户访问了论坛", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View(bllSession.ITopicforumBLL.GetList("").ToPagedList(page,10));
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            Topicforum topicforum = new Topicforum();
            topicforum = bllSession.ITopicforumBLL.GetEntity(id);
            topicforum.Browses = topicforum.Browses + 1;
            bllSession.ITopicforumBLL.Update(topicforum);
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户访问了帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
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
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户访问准备发布新的帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View();
        }

        /// <summary>
        /// 添加主题
        /// </summary>
        /// <param name="title"></param>
        /// <param name="classify"></param>
        /// <param name="conten"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]  //允许特殊字符提交/
        public ActionResult Add(string title, int classify, string conten)
        {
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户发布了新的帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View();
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
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户回复了帖子", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View();
        }

        /// <summary>
        /// 板块显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Forum(int id, int Time = 0, string Publish = "", int Rule = 0, int p = 0)
        {
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户访问板块展示页面", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
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
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户签到", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            return View();
        }

        /// <summary>
        /// 显示签到信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignInfo()
        {
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户查看了签到信息", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
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
            char Username = FormsAuthentication.FormsCookieName.Single();
            log.Info(new LogContent(Username + "用户举报", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
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
            return View();
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CancelCollectForum(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CollectShow(int id)
        {
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