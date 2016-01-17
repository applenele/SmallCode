using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;
using NW.BLL;
using NW.Log4net;
using NW.Entity.DataModels;
using NW.Utility;

namespace NW.Helper
{
    public class CacheHelper
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("myLogger");

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCacheValue(string key)
        {
            return HttpRuntime.Cache[key];
        }

        /// <summary>
        /// 重置缓存值  如果为空值则赋值 不为空则为直接返回
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <returns>返回cache value</returns>
        public static object ResetCacheValue(string key, string value, DateTime expireTime)
        {
            object obj = GetCacheValue(key);
            if (obj == null)
            {
                Insert(key, value, expireTime);
                return value;
            }
            else
            {
                return obj;
            }
        }


        /// <summary>
        /// 增加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        public static void Insert(string key, object value, DateTime expireTime)
        {
            object cached = HttpRuntime.Cache[key];
            if (cached == null)
            {
                HttpRuntime.Cache.Insert(key, value, null, expireTime, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable,
                         new System.Web.Caching.CacheItemRemovedCallback(OnMoveCacheBack)//移除时调用的回调函数
                    );
                log.Info(new LogContent("cache record:增加缓存" + key + ":" + value, LogType.记录.ToString(), HttpHelper.GetServerIP()));
            }
        }

        /// <summary>
        ///  增加缓存带回调函数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <param name="onRemoveCallback"></param>
        public static void Insert(string key, object value, DateTime expireTime, CacheItemRemovedCallback onRemoveCallback)
        {
            object cached = HttpRuntime.Cache[key];
            if (cached == null)
            {
                HttpRuntime.Cache.Insert(key, value, null, expireTime, Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.NotRemovable,
                         new System.Web.Caching.CacheItemRemovedCallback(onRemoveCallback)//移除时调用的回调函数
                    );
                log.Info(new LogContent("cache record:增加缓存 带缓存方法" + key + ":" + value, LogType.记录.ToString(), HttpHelper.GetServerIP()));
            }
        }

        /// <summary>
        ///  移除缓存调用回调 通用回调
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="reason"></param>
        private static void OnMoveCacheBack(string key, object value, CacheItemRemovedReason reason)
        {
            log.Info(new LogContent("cache record:缓存移除回调" + key + ":" + value, LogType.记录.ToString(), HttpHelper.GetServerIP()));
        }

    }
}