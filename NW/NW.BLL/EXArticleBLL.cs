using NW.DAL;
using NW.Entity;
using NW.IBLL;
using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public class EXArticleBLL : BaseBLL<EXArticle>, IEXArticleBLL
    {
        /// <summary>
        ///  得到某个日期时间段的增加的博客
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetAddRecordsCountByDate(DateTime begin, DateTime end)
        {
            return DBSessionFactory.GetDBSession().EXArticleDAL.GetAddRecordsCountByDate(begin, end);
        }

        /// <summary>
        /// 得到某个日期时间段的更新的博客
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetUpdateRecordsCountByDate(DateTime begin, DateTime end)
        {
            return DBSessionFactory.GetDBSession().EXArticleDAL.GetUpdateRecordsCountByDate(begin, end);
        }

        public override void SetDAL()
        {
            idal = DBSessionFactory.GetDBSession().EXArticleDAL;
        }
    }
}
