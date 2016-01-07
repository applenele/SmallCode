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
    public class ReplyDAL : BaseDAL<Reply>, IBaseDAL<Reply>, IReplyDAL
    {
        public ReplyDAL()
        {
            base.t = new Reply();
        }

        public new Reply GetEntity(int id)
        {
            string query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id where r.Id = @Id";
            using (Conn)
            {
                var data = Conn.Query<Reply, User, Reply>(query, (reply, user) => { reply.User = user; return reply; }, new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public Reply GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Reply> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id left join Reply rr on r.Id = rr.FatherId LEFT JOIN User uu on rr.UserId = uu.Id  where r.FatherId is null order by r.Time desc";
                }
                else
                {
                    query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id left join Reply rr on r.Id = rr.FatherId LEFT JOIN User uu on rr.UserId = uu.Id  where r.FatherId is null and " + whereStr + " order by r.Time desc";
                }
                Reply lookup = null;
                var data = Conn.Query<Reply, User, Reply, User, Reply>(query,
                    (reply, user, child, _user) =>
                    {
                        reply.User = user;
                        if (lookup == null || lookup.Id != reply.Id)
                        {
                            lookup = reply;
                        }
                        if (child != null)
                        {
                            child.User = _user;
                            lookup.Children.Add(child);
                        }
                        return lookup;
                    }).Distinct();

                return data;
            }
        }

        public IEnumerable<Reply> GetReplyAllFather(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id left join Reply rr on r.Id = rr.FatherId LEFT JOIN User uu on rr.UserId = uu.Id  order by r.Time desc";
                }
                else
                {
                    query = "SELECT * FROM Reply r left join User u on r.UserId = u.Id left join Reply rr on r.Id = rr.FatherId LEFT JOIN User uu on rr.UserId = uu.Id  where " + whereStr + " order by r.Time desc";
                }
                Reply lookup = null;
                var data = Conn.Query<Reply, User, Reply, User, Reply>(query,
                    (reply, user, child, _user) =>
                    {
                        reply.User = user;
                        if (lookup == null || lookup.Id != reply.Id)
                        {
                            lookup = reply;
                        }
                        if (child != null)
                        {
                            child.User = _user;
                            lookup.Children.Add(child);
                        }
                        return lookup;
                    }).Distinct();

                return data;
            }
        }

    }
}
