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
    public class EXArticleTempDAL : BaseDAL<EXArticleTemp>, IEXArticleTempDAL
    {
        public EXArticleTempDAL()
        {
            base.t = new EXArticleTemp();
        }



        #region 弃用
        //public new int Insert(EXArticleTemp model)
        //{
        //    using (Conn)
        //    {
        //        string query = "INSERT INTO EXArticleTemp (Title,Description,Source,URL,OldBrowses,Category,Label,ReplyCount,IsDelete,CreateDate) VALUES (@Title,@Description,@Source,@URL,@OldBrowses,@Category,@Label,@ReplyCount,@IsDelete,@CreateDate)";
        //        return Conn.Execute(query, model);
        //    }
        //}

        //public new int Update(EXArticleTemp model)
        //{
        //    using (Conn)
        //    {
        //        string query = "UPDATE EXArticleTemp SET   Title=@Title,Description=@Description,Source=@Source,URL=@URL,OldBrowses=@OldBrowses,Category=@Category,Label=@Label,ReplyCount=@ReplyCount,IsDelete=@IsDelete,CreateDate=@CreateDate WHERE Id =@Id";
        //        return Conn.Execute(query, model);
        //    }
        //} 
        #endregion

        public EXArticleTemp GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  得到某个个时间段内的增加的临时博客的数量
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetAddRecordsCountByDate(DateTime begin, DateTime end)
        {
            int total = 0;
            string query = "SELECT count(*) as Total FROM EXArticleTemp  WHERE DATEDIFF(CreateDate,@Begin)>=0 and  DATEDIFF(CreateDate,@End) <=0";
            using (Conn)
            {
                DapperCount count = Conn.Query<DapperCount>(query, new { Begin = begin.ToString("yyyy-MM-dd"), End = end.ToString("yyyy-MM-dd") }).SingleOrDefault();
                total = count.Total;
            }
            return total;
        }

        /// <summary>
        ///  得到某个个时间段内的更新的临时博客的数量
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int GetUpdateRecordsCountByDate(DateTime begin, DateTime end)
        {
            int total = 0;
            string query = "SELECT count(*) as Total FROM EXArticleTemp  WHERE DATEDIFF(ModifyDate,@Begin)>=0 and  DATEDIFF(ModifyDate,@End) <=0";
            using (Conn)
            {
                DapperCount count = Conn.Query<DapperCount>(query, new { Begin = begin, End = end }).SingleOrDefault();
                total = count.Total;
            }
            return total;
        }
    }
}
