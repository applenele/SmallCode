using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NW.DAL
{
    /// <summary>
    /// dbsession 工厂
    /// </summary>
    public class DBSessionFactory
    {
        public static DBSession GetDBSession()
        {
            DBSession dbsession = CallContext.GetData(typeof(DBSessionFactory).Name) as DBSession;
            if (dbsession == null)
            {
                dbsession = new DBSession();
                CallContext.SetData(typeof(DBSessionFactory).Name, dbsession);
            }
            return dbsession;
        }
    }
}
