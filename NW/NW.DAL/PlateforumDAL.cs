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
    public class PlateforumDAL : BaseDAL<Plateforum>, IBaseDAL<Plateforum>, IPlateforumDAL
    {

        public PlateforumDAL()
        {
            base.t = new Plateforum();
        }

        public Plateforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Plateforum> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Plateforum where " + whereStr + "order by Time desc";
                }
                else
                {
                    query = "SELECT * FROM Plateforum order by Time desc";
                }
                return Conn.Query<Plateforum>(query);
            }
        }

    }
}
