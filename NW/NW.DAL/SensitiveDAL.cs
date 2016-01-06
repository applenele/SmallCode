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
    class SensitiveDAL : BaseDAL<Sensitive>, ISensitiveDAL
    {
        public SensitiveDAL()
        {
            base.t = new Sensitive();
        }

        public Sensitive GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Sensitive> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM `Sensitive` where " + whereStr + " order by Name desc";
                }
                else
                {
                    query = "SELECT * FROM `Sensitive` order by Name desc";
                }

                return Conn.Query<Sensitive>(query);
            }
        }

    }
}
