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
    public class TopicforumDAL : IBaseDAL<Topicforum>, ITopicforumDAL
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
                string query = "DELETE FROM Topicforum WHERE Id=@Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Topicforum model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Topicforum WHERE Id=@Id";
                return Conn.Execute(query, model);
            }
        }

        public Topicforum GetEntity(int id)
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

        public IEnumerable<Topicforum> GetList(string whereStr)
        {
            string query = "";
            using (Conn)
            {
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Topicforum t left join User u on t.UserId = u.Id WHERE " + whereStr + "order by t.Time desc"; 
                }
                else
                {
                    query = "SELECT * FROM Topicforum t left join User u on t.UserId = u.Id order by t.Time desc";
                }
                var data = Conn.Query<Topicforum, User, Topicforum>(query, (topicforum, user) => { topicforum.User = user; return topicforum; });
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

        public int Insert(Topicforum model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Topicforum(Title,Content,Top,Time,LastReply,UserId,Reward,Report)VALUES(@Title,@Content,@Top,@Time,@LastReply,@UserId,@Reward,@Report)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Topicforum model)
        {
            using (Conn)
            {
                string query = "UPDATE Topicforum SET Title=@Title,Content=@Content,Top=@Top,Time=@Time,LastReply=@LastReply,Reward=@Reward,Report=@Report,IsShow=@IsShow,IsClose=@IsClose,IsOfficeIdentified=@IsOfficeIdentified";
                return Conn.Execute(query, model);
            }
        }
    }
}
