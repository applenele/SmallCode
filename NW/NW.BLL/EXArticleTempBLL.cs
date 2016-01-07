using NW.DAL;
using NW.Entity;
using NW.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public class EXArticleTempBLL : BaseBLL<EXArticleTemp>, IEXArticleTempBLL
    {
        /// <summary>
        ///  得到某个个时间段内的增加的临时博客的数量
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetAddRecordsCountByDate(DateTime begin, DateTime end)
        {
            return DBSessionFactory.GetDBSession().EXArticleTempDAL.GetAddRecordsCountByDate(begin, end);
        }

        /// <summary>
        ///  得到某个个时间段内的更新的临时博客的数量
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetUpdateRecordsCountByDate(DateTime begin, DateTime end)
        {
            return DBSessionFactory.GetDBSession().EXArticleTempDAL.GetUpdateRecordsCountByDate(begin, end);
        }

        public override void SetDAL()
        {
            idal = DBSessionFactory.GetDBSession().EXArticleTempDAL;
        }
    }
}
