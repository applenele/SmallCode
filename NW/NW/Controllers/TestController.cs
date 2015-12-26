using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            Dictionary<string,string> badWords =new Dictionary<string, string>();
            badWords.Add("sb","*");
            badWords.Add("傻逼","#");
            WordFilter.Add(1,badWords);
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