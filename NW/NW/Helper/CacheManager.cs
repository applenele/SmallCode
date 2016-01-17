using NW.BLL;
using NW.Entity.ViewModels;
using NW.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace NW.Helper
{
    public class CacheManager
    {
        public readonly BLLSession bllSession = BLLSessionFactory.GetBLLSession();

        public readonly int CacheTime =Convert.ToInt32(Utility.ConfigurationHelper.GetValue("CacheTime"));

        public CacheManager()
        {
            EXArticleCachaeManager();
            ArticleCacheManager();
        }

        /// <summary>
        ///  EXArticleCachaeManager 管理
        /// </summary>
        public void EXArticleCachaeManager()
        {
            DateTime now = DateTime.Now;
            object AddRecordValue = CacheHelper.GetCacheValue("AddExArticleRecordCount");
            object UpdateRecordValue = CacheHelper.GetCacheValue("UpdateExArticleRecordCount");
            if (AddRecordValue == null || UpdateRecordValue == null)
            {
                AddRecordValue = bllSession.IEXArticleTempBLL.GetAddRecordsCountByDate(now, now);
                UpdateRecordValue = bllSession.IEXArticleTempBLL.GetUpdateRecordsCountByDate(now, now);
                CacheHelper.Insert("AddExArticleRecordCount", AddRecordValue, now.AddMinutes(CacheTime), AddExArticleRecordCountOnRemoveCallback);
                CacheHelper.Insert("UpdateExArticleRecordCount", UpdateRecordValue, now.AddMinutes(CacheTime), UpdateExArticleRecordCountOnRemoveCallback);
            }
        }


        public void ArticleCacheManager()
        {
            DateTime now = DateTime.Now;
            object Categories = CacheHelper.GetCacheValue("ArticleCategories");
            object Calendars = CacheHelper.GetCacheValue("ArticleCalendars");
            if (Categories == null || Calendars == null)
            {
                Categories = SideHelper.GetSideCategoryCategories();
                Calendars = SideHelper.GetSideArticleCalendars();
                CacheHelper.Insert("ArticleCategories", Categories, now.AddMinutes(CacheTime), ArticleCategoriesOnRemoveCallback);
                CacheHelper.Insert("ArticleCalendars", Calendars, now.AddMinutes(CacheTime), ArticleCalendarsOnRemoveCallback);
            }
        }

        /// <summary>
        ///  博客缓存回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        private void ArticleCalendarsOnRemoveCallback(string key, object value, CacheItemRemovedReason reason)
        {
            DateTime now = DateTime.Now;
            var Calendars = SideHelper.GetSideArticleCalendars();
            object obj = CacheHelper.GetCacheValue(key);
            if (obj != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
            CacheHelper.Insert("ArticleCalendars", Calendars, now.AddMinutes(CacheTime), ArticleCategoriesOnRemoveCallback);
        }

        /// <summary>
        /// 博客日历回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        private void ArticleCategoriesOnRemoveCallback(string key, object value, CacheItemRemovedReason reason)
        {
            DateTime now = DateTime.Now;
            var Categories = SideHelper.GetSideCategoryCategories();
            object obj = CacheHelper.GetCacheValue(key);
            if (obj != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
            CacheHelper.Insert("ArticleCategories", Categories, now.AddMinutes(CacheTime), ArticleCategoriesOnRemoveCallback);
        }

        /// <summary>
        ///  exarticle AddExArticleRecordCount 缓存回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        private void UpdateExArticleRecordCountOnRemoveCallback(string key, object value, CacheItemRemovedReason reason)
        {
            DateTime now = DateTime.Now;
            int addRecords = bllSession.IEXArticleTempBLL.GetUpdateRecordsCountByDate(now, now);
            object obj = CacheHelper.GetCacheValue(key);
            if (obj != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
            CacheHelper.Insert("UpdateExArticleRecordCount", addRecords, now.AddMinutes(CacheTime), UpdateExArticleRecordCountOnRemoveCallback);
        }

        /// <summary>
        /// exarticle AddExArticleRecordCount 缓存回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        private void AddExArticleRecordCountOnRemoveCallback(string key, object value, CacheItemRemovedReason reason)
        {
            DateTime now = DateTime.Now;
            int addRecords = bllSession.IEXArticleTempBLL.GetAddRecordsCountByDate(now, now);
            object obj = CacheHelper.GetCacheValue(key);
            if (obj != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
            CacheHelper.Insert("AddExArticleRecordCount", addRecords, now.AddMinutes(CacheTime), AddExArticleRecordCountOnRemoveCallback);
        }
    }
}