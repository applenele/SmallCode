using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using NW.IDAL;
using Dapper;
using NW.Entity.DataModels;

namespace NW.DAL
{
    public class EXArticleDAL : BaseDAL<EXArticle>, IEXArticleDAL
    {
        public EXArticleDAL()
        {
            base.t = new EXArticle();
        }



        public EXArticle GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 得到 几日增加记录
        /// </summary>
        /// <returns></returns>
        public int GetAddRecordsCountByDate(DateTime begin, DateTime end)
        {
            int total = 0;
            string query = "SELECT count(*) as Total FROM EXArticle  WHERE DATEDIFF(CreateDate,@Begin)>=0 and  DATEDIFF(CreateDate,@End) <=0";
            using (Conn)
            {
                DapperCount count = Conn.Query<DapperCount>(query, new { Begin = begin, End = end }).SingleOrDefault();
                total = count.Total;
            }
            return total;
        }

        /// <summary>
        ///  得到今日更新记录
        /// </summary>
        /// <returns></returns>
        public int GetUpdateRecordsCountByDate(DateTime begin, DateTime end)
        {
            int total = 0;
            string query = "SELECT count(*) as Total FROM EXArticle  WHERE DATEDIFF(ModifyDate,@Begin)>=0 and  DATEDIFF(ModifyDate,@End) <=0";
            using (Conn)
            {
                DapperCount count = Conn.Query<DapperCount>(query, new { Begin = begin, End = end }).SingleOrDefault();
                total = count.Total;
            }
            return total;
        }
    }
}
