using NW.Entity;
using NW.Entity.DataModels;
using NW.Filter;
using NW.Helper;
using NW.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class EXArticleController : BaseController
    {
        #region 正式的文章
        /// <summary>
        ///  正式文章
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        // GET: Admin/EXArticle
        public ActionResult Index(string Key, int page = 1)
        {
            int total = 0;
            string whereStr = "";
            if (!string.IsNullOrEmpty(Key))
            {
                whereStr += " Title like '%" + Key + "%' ";
            }
            IEnumerable<EXArticle> articles = bllSession.IEXArticleBLL.GetListByPage(page, 20, whereStr, out total);
            DateTime now = DateTime.Now;
            ViewBag.TodayAddCount = bllSession.IEXArticleBLL.GetAddRecordsCountByDate(now, now);
            ViewBag.TodayUpdateCount = bllSession.IEXArticleBLL.GetUpdateRecordsCountByDate(now, now);
            return View(articles.ToPagedList(page, 20, total));
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "删除文章")]
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.IEXArticleBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }

        /// <summary>
        /// 展示文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Show(int id)
        {
            EXArticle article = new EXArticle();
            article = bllSession.IEXArticleBLL.GetEntity(id);
            return View(article);
        }

        /// <summary>
        /// 博客批删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "博客批删除")]
        public ActionResult MutiDelete(string ids)
        {
            try
            {
                string[] idsStrArr = ids.Split(',');
                foreach (var id in idsStrArr)
                {
                    bllSession.IEXArticleBLL.Delete(Convert.ToInt32(id));
                }
                return Content("ok");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 临时的博客
        /// <summary>
        /// 临时文章
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult TempIndex(string Key, int page = 1)
        {
            int total = 0;
            string whereStr = "";
            if (!string.IsNullOrEmpty(Key))
            {
                whereStr += " Title like '%" + Key + "%' ";
            }
            IEnumerable<EXArticleTemp> articleTemps = bllSession.IEXArticleTempBLL.GetListByPage(page, 20, whereStr, out total);
            DateTime now = DateTime.Now;

            object AddRecordValue = CacheHelper.GetCacheValue("AddExArticleRecordCount");
            object UpdateRecordValue = CacheHelper.GetCacheValue("UpdateExArticleRecordCount");

            ViewBag.TodayAddCount = AddRecordValue;
            ViewBag.TodayUpdateCount = UpdateRecordValue;
            return View(articleTemps.ToPagedList(page, 20, total));
        }

       
        /// <summary>
        /// 批量删除临时的博客
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "临时博客批删除")]
        public ActionResult TempMutiDelete(string ids)
        {
            try
            {
                string[] idsStrArr = ids.Split(',');
                foreach (var id in idsStrArr)
                {
                    bllSession.IEXArticleTempBLL.Delete(Convert.ToInt32(id));
                }
                return Content("ok");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除临时的文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "删除临时文章")]
        public ActionResult TempDelete(int id)
        {
            try
            {
                bllSession.IEXArticleTempBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }

        /// <summary>
        /// 临时文章导入正式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoLog(Description = "临时文章导入正式")]
        public ActionResult TempImport(int id)
        {
            try
            {
                TempImportFunc(id);
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Content("err");
            }
        }

        /// <summary>
        /// 临时文章展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TempShow(int id)
        {
            EXArticleTemp article = new EXArticleTemp();
            article = bllSession.IEXArticleTempBLL.GetEntity(id);
            return View(article);
        }

        /// <summary>
        /// 批量导入文章
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AutoLog(Description = "批量导入文章")]
        [HttpPost]
        public ActionResult TempMutiImport(string ids)
        {
            try
            {
                string[] idsStrArr = ids.Split(',');
                foreach (var id in idsStrArr)
                {
                    TempImportFunc(Convert.ToInt32(id));
                }
                return Content("ok");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 将临时的导入到正式的方法
        /// </summary>
        /// <param name="id"></param>
        public void TempImportFunc(int id)
        {
            EXArticleTemp temp = new EXArticleTemp();
            temp = bllSession.IEXArticleTempBLL.GetEntity(id);
            EXArticle article = new EXArticle();
            article = bllSession.IEXArticleBLL.GetEntity(temp.Id);
            if (article == null)
            {
                article = temp;
                article.Browses = 0;
                article.CreateBy = CurrentUser.Id;
                article.CreateDate = DateTime.Now;
                article.IsDelete = false;
                article.Status = EXArticleStatus.显示;
                bool result = bllSession.IEXArticleBLL.Insert(article);
                temp.Status = EXArticleTempStatus.导入;
                bllSession.IEXArticleTempBLL.Update(temp);
            }
            else
            {
                article.Title = temp.Title;
                article.Description = temp.Description;
                article.OldBrowses = temp.OldBrowses;
                article.ModifyBy = CurrentUser.Id;
                article.ModifyDate = DateTime.Now;
                article.Label = temp.Label;
                article.Category = temp.Category;
                article.Source = temp.Source;
                article.URL = temp.URL;
                article.ReplyCount = temp.ReplyCount;
                bool result = bllSession.IEXArticleBLL.Update(article);
                temp.Status = EXArticleTempStatus.导入;
                bllSession.IEXArticleTempBLL.Update(temp);
            }
        }


        [HttpGet]
        public ActionResult TempAmountStats()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTempDataByDate(DateTime? Begin, DateTime? End)
        {
            if (!Begin.HasValue)
            {
                Begin = DateTime.Now.AddDays(-7);

            }
            if (!End.HasValue)
            {
                End = DateTime.Now.AddDays(7);
            }
            return Json(bllSession.IEXArticleTempBLL.GetAddAndUpdateRecordsByDate(Convert.ToDateTime(Begin), Convert.ToDateTime(End)), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}