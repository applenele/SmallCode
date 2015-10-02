using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NW.Factory
{
    public class ConnectionFactory
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["mysqldb"].ConnectionString;

        public static IDbConnection CreateConnection()
        {
            IDbConnection conn = null;
            conn = CallContext.GetData(typeof(ConnectionFactory).Name) as IDbConnection;
            if (conn == null)
            {
                conn = new MySqlConnection(connString);
                CallContext.SetData(typeof(ConnectionFactory).Name, conn);
            }
            return conn;
        }
    }
}
