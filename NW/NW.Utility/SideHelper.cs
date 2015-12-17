using NW.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.BLL;
using NW.Entity;

namespace NW.Utility
{
    public static class SideHelper
    {
        /// <summary>
        ///  文章右边分类
        /// </summary>
        /// <returns></returns>
        public static List<SideArticleCategory> GetSideCategoryCategories()
        {
            BLL.BLLSession bllSession = BLLSessionFactory.GetBLLSession();
            List<Category> Categories = new List<Category>();
            Categories = bllSession.ICategoryBLL.GetList("").ToList();
            List<SideArticleCategory> Sides = new List<SideArticleCategory>();
            foreach (var item in Categories)
            {
                SideArticleCategory side = new SideArticleCategory();
                side.Id = item.Id;
                side.Description = item.Description;
                int count = bllSession.IArticleBLL.GetList("Category='" + item.Description + "'").Count();
                side.Count = count;
                Sides.Add(side);
            }
            return Sides;
        }

        /// <summary>
        /// 按照日期查找
        /// </summary>
        /// <returns></returns>
        public static List<SideArticleCalendar> GetSideArticleCalendars()
        {
            BLL.BLLSession bllSession = BLLSessionFactory.GetBLLSession();
            List<SideArticleCalendar> Sides = new List<SideArticleCalendar>();

            //分开写 容易懂
            //List<DateTime> dates = bllSession.IArticleBLL.GetList("").Select(a => a.Time).ToList();
            //Sides = dates.GroupBy(a => a.Date).Select(g =>(new SideArticleCalendar() {DateShow = g.Key,Count =  g.Count()})).ToList();

            Sides = bllSession.IArticleBLL.GetList("")
                .Select(a => a.Time)
                .GroupBy(a => a.GetDateTimeFormats('y')[0])
                .Select(g => (new SideArticleCalendar() { DateDisplay = g.Key, Count = g.Count() }))
                .ToList();
            return Sides;
        }
    }
}
