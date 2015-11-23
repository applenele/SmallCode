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
    public class NotificationDAL : INotificationDAL
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
                string query = "DELETE FROM Notification WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Notification model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Notification WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Notification GetEntity(int id)
        {
            Notification notification;
            string query = "SELECT * FROM Notification WHERE Id = @Id";
            using (Conn)
            {
                notification = Conn.Query<Notification>(query, new { Id = id }).SingleOrDefault();
                return notification;
            }
        }

        public Notification GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Notification where " + whereStr + " order by  Priority asc,CreatedTime desc";
                }
                else
                {
                    query = "SELECT * FROM Notification order by Priority asc,CreatedTime desc";
                }
                return Conn.Query<Notification>(query);
            }
        }

        public IEnumerable<Notification> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Notification model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Notification(CreatedTime,Description,Priority,IsShow)VALUES(@CreatedTime,@Description,@Priority,@IsShow)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Notification model)
        {
            using (Conn)
            {
                string query = "UPDATE Notification SET  CreatedTime=@CreatedTime,Description=@Description,Priority=@Priority,IsShow=@IsShow WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
