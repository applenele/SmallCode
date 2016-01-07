using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using System.Data;
using NW.Factory;
using Dapper;

namespace NW.DAL
{
    public class ReplyforumDAL : BaseDAL<Replyforum>, IBaseDAL<Replyforum>, IReplyforumDAL
    {
        public ReplyforumDAL()
        {
            base.t = new Replyforum();
        }

        public new Replyforum GetEntity(int id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM Replyforum r join User u on r.UserId = u.Id WHERE Id=@Id";
                var data = Conn.Query<Replyforum, User, Replyforum>(query, (replyforum, user) => { replyforum.User = user; return replyforum; }, new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public Replyforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Replyforum> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Replyforum r join User u on r.UserId = u.Id left join Replyforum rr on u.Id = rr.FatherId left join User uu on rr.UserId = uu.Id where r.FatherId is null order by r.Time desc ";
                }
                else
                {
                    query = "SELECT * FROM Replyforum r join User u on r.UserId = u.Id left join Replyforum rr on u.Id = rr.FatherId left join User uu on rr.UserId = uu.Id where r.FatherId is null and " + whereStr + "order by r.Time desc";
                }
                Replyforum lookup = null;
                var data = Conn.Query<Replyforum, User, Replyforum, User, Replyforum>(query,
                    (replyforum, user, child, _user) =>
                    {
                        replyforum.User = user;
                        if (lookup == null || lookup.Id != user.Id)
                        {
                            lookup = replyforum;
                        }
                        if (child != null)
                        {
                            child.User = _user;
                            lookup.Children.Add(child);
                        }
                        return lookup;
                    }
                ).Distinct();
                return data;
            }
        }

        public IEnumerable<Replyforum> GetReplyforumAllFather(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Replyforum r left join User u on r.UserId = u.Id left join Replyforum rr on r.Id = rr.FatherId left join User uu on rr.UserId = uu.Id  order by r.Time desc";
                }
                else
                {
                    query = "SELECT * FROM Replyforum r left join User u on r.UserId = u.Id left join Replyforum rr on r.Id = rr.FatherId left join User uu on rr.UserId = uu.Id  where " + whereStr + " order by r.Time desc";
                }
                Replyforum lookup = null;
                var data = Conn.Query<Replyforum, User, Replyforum, User, Replyforum>(query,
                    (replyforum, user, child, _user) =>
                    {
                        replyforum.User = user;
                        if (lookup == null || lookup.Id != replyforum.Id)
                        {
                            lookup = replyforum;
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
