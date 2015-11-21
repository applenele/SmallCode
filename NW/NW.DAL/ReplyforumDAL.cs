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
    public class ReplyforumDAL : IBaseDAL<Replyforum>, IReplyforumDAL
    {
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                return _conn = ConnectionFactory.CreateConnection();
            }
        }
        public int Delete(int id)
        {
            using (Conn)
            {
                string query = "DELETE FROM Replyforum WHERE Id=@Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Replyforum model)
        {
            throw new NotImplementedException();
        }

        public Replyforum GetEntity(int id)
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

        public IEnumerable<Replyforum> GetList(string whereStr)
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
                    query = "SELECT * FROM Replyforum r join User u on r.UserId = u.Id left join Replyforum rr on u.Id = rr.FatherId left join User uu on rr.UserId = uu.Id where r.FatherId is null and "+ whereStr +"order by r.Time desc";
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

        public IEnumerable<Replyforum> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
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

        public int Insert(Replyforum model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Replyforum(TopicId,Content,Time,UserId,FatherId)VALUES(@TopicId,@Content,@Time,@UserId,@FatherId)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Replyforum model)
        {
            using (Conn)
            {
                string query = "UPDATE Replyforum SET TopicId=@TopicId,Content=@Content,Time=@Time,UserId=@UserId,FatherId=@FatherId";
                return Conn.Execute(query, model);
            }
        }
    }
}
