using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NW.Entity;

namespace NW.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            Dictionary<string, string> badWords = new Dictionary<string, string>();
            badWords.Add("sb", "*");
            badWords.Add("傻逼", "#");
            WordFilter.Add(1, badWords);
            return View();
        }

        [HttpGet]
        public ActionResult TestPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestPost(string TestStr)
        {
            bool result = false;
            string str = TextFilter(TestStr, out result);
            return View();
        }

        /// <summary>
        /// 单个对象过滤
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowTest()
        {
            bllSession.IArticleBLL.GetEntity(3);
            bool result = false;
            Article article = bllSession.IArticleBLL.GetEntity(3);
            article = WordFilterHelper<Article>.TextFilter(article, out result) as Article;
            return View(article);
        }

        /// <summary>
        ///   集合的过滤
        /// </summary>
        /// <returns></returns>
        public ActionResult ListTest()
        {
            List<Article> list = bllSession.IArticleBLL.GetList("").ToList();
            bool result = false;
            list = WordFilterHelper<Article>.TextFilter(list, out result) as List<Article>;
            return View(list);
        }


        /// <summary>
        /// 内容过滤
        /// </summary>
        /// <param name="body">待过滤内容</param>
        /// <param name="isBanned">是否禁止提交</param>
        private string TextFilter(string body, out bool isBanned)
        {
            isBanned = false;
            if (string.IsNullOrEmpty(body))
            {
                return body;
            }

            string temBody = body;
            WordFilterStatus staus = WordFilterStatus.Replace;
            temBody = WordFilter.SensitiveWordFilter.Filter(body, out staus);

            if (staus == WordFilterStatus.Banned)
            {
                isBanned = true;
                return body;
            }
            body = temBody;
            return body;
        }

    }
}