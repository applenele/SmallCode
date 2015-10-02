using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Utility
{
    public class DateHelper
    {
        #region 获取时间戳
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion


        /// <summary>
        /// 两个时间之间的天数
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int DifferenceDays(DateTime time1, DateTime time2)
        {
            int ret = 0;
            ret = (time1 - time2).Days;
            return ret;
        }
    }
}
