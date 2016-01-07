using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiebaNet.Segmenter;
using NW.Entity;
using NW.Lucene;
using System.Diagnostics;
using NW.Web.Helper;

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
        ///  单个字符串的过滤
        /// </summary>
        /// <returns></returns>
        public ActionResult TextTest()
        {
            bool result = false;
            ViewBag.Text = WordFilterHelperExtension.ToTextFilter("sb ,我们,挨了一炮", out result);
            return View();
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


        public ActionResult TestSearch()
        {
            var seg = new JiebaSegmenter();
            seg.AddWord("机器学习");

            NewsSearcher.ClearLuceneIndex();

            var data = NewsRepository.GetAll();
            NewsSearcher.UpdateLuceneIndex(data);

            var results = NewsSearcher.Search("方法研究");


            return View(results);
        }

        [HttpGet]
        public ActionResult BlogSearchTest()
        {
            return View();
        }

        /// <summary>
        /// 创建索引
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateIndex()
        {
            var seg = new JiebaSegmenter();
            seg.AddWord("Bolg");

            BlogSearcher.ClearLuceneIndex();
            Stopwatch st = new Stopwatch();//实例化类
            st.Start();//开始计时
            var data = bllSession.IArticleBLL.GetList("");
            BlogSearcher.UpdateLuceneIndex(data);
            st.Stop();//终止计时
            System.Diagnostics.Debug.WriteLine("执行时间：" + st.ElapsedMilliseconds);
            return Redirect("/Test/BlogSearchTest");
        }

        [HttpPost]
        public ActionResult BlogSearchTest(string Key)
        {
            var results = BlogSearcher.Search(Key, 1, 10);
            ViewBag.Result = results;
            return View();
        }

        public ActionResult UrlTest()
        {
            return View();
        }

        /// <summary>
        ///  http://echarts.baidu.com/  测试
        /// </summary>
        /// <returns></returns>
        public ActionResult ChartTest()
        {
            return View();
        }
    }
}