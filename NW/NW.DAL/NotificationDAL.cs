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
    public class NotificationDAL : BaseDAL<Notification>, INotificationDAL
    {
        public NotificationDAL()
        {
            base.t = new Notification();
        }

        public Notification GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Notification> GetList(string whereStr)
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
        
    }
}
