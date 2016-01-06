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
    public class TopicforumDAL : BaseDAL<Topicforum>, ITopicforumDAL
    {
        public TopicforumDAL()
        {
            base.t = new Topicforum();
        }

        public new Topicforum GetEntity(int id)
        {
            string query = "SELECT * FROM Topicforum t join User u on t.UserId = u.Id WHERE t.Id = @Id";
            using (Conn)
            {
                var data = Conn.Query<Topicforum, User, Topicforum>(query, (topicforum, user) => { topicforum.User = user; return topicforum; }, new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public Topicforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Topicforum> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Topicforum t left join User u on t.UserId = u.Id left join Plateforum p on p.Id = t.PlateforumId WHERE" + whereStr + "order by t.Time desc";
                }
                else
                {
                    query = "SELECT * FROM Topicforum t left join User u on t.UserId = u.Id left join Plateforum p on p.Id = t.PlateforumId order by t.Time desc";
                }
                var data = Conn.Query<Topicforum, User, Plateforum, Topicforum>(query, (topicforum, user, plateforum) => { topicforum.User = user; topicforum.Plateforum = plateforum; return topicforum; });
                return data;
            }
        }


        public IEnumerable<Topicforum> GetListByPage(int page, int size, string whereStr)
        {
            int index = size * (page - 1);
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Topicforum where " + whereStr + "order by Time desc limit " + index + "," + size;
                }
                else
                {
                    query = "SELECT * FROM Topicforum order by Time desc limit " + index + "," + size;
                }
                return Conn.Query<Topicforum>(query);
            }
        }


    }
}
