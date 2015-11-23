using NW.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class ForumController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            List <Topicforum> topicforums = new List<Topicforum>();
            topicforums = bllSession.ITopicforumBLL.GetList("").ToList();
            return View(bllSession.ITopicforumBLL.GetList("").ToPagedList(page,10));
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            Topicforum topicforum = new Topicforum();
            topicforum = bllSession.ITopicforumBLL.GetEntity(id);
            topicforum.Browses = topicforum.Browses + 1;
            bllSession.ITopicforumBLL.Update(topicforum);
            return View(topicforum);
        }

        /// <summary>
        /// 添加主题
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
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
            return View();
        }

        /// <summary>
        /// 板块显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Forum(int id, int Time = 0, string Publish = "", int Rule = 0, int p = 0)
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
            return View();
        }

        /// <summary>
        /// 显示签到信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignInfo()
        {
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