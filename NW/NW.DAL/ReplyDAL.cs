using NW.Entity;
using NW.Factory;
using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NW.DAL
{
    public class ReplyDAL : IBaseDAL<Reply>, IReplyDAL
    {

        #region 得到数据库链接对象
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                return _conn = ConnectionFactory.CreateConnection();
            }
        }
        #endregion

        public int Delete(int id)
        {
            using (Conn)
            {
                string query = "DELETE FROM Reply WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Reply model)
        {
            throw new NotImplementedException();
        }

        public Reply GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Reply GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id left join Reply rr on r.Id = rr.FatherId  where r.FatherId is null " + whereStr + "  order by  r.Time desc";
                }
                else
                {
                    query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id left join Reply rr on r.Id = rr.FatherId  where r.FatherId is null order by r.Time desc";
                }
                Reply lookup = null;
                var data = Conn.Query<Reply, User, Reply, Reply>(query,
                    (reply, user, father) =>
                    {
                        reply.User = user;
                        if (lookup == null || lookup.Id != reply.Id)
                            lookup = reply;
                        if (father != null)
                            lookup.Children.Add(father);
                        return lookup;
                    });

                return data;
            }
        }

        public IEnumerable<Reply> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Reply model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Reply(UserId,BlogId,Description,FatherId,Time)VALUES(@UserId,@BlogId,@Description,@FatherId,@Time)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Reply model)
        {
            using (Conn)
            {
                string query = "UPDATE Reply SET  UserId=@UserId,BlogId = @BlogId,Description=@Description,FatherId=@FatherId,Time=@Time WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
