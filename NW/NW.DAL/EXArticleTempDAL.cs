using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using NW.IDAL;
using Dapper;

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

    }
}
