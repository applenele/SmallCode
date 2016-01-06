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
    class DemandDAL : BaseDAL<Demand>, IBaseDAL<Demand>, IDemandDAL
    {
        public DemandDAL()
        {
            base.t = new Demand();
        }

        public new Demand GetEntity(int id)
        {
            string query = "SELECT * FROM Demand d LEFT JOIN user u on u.Id = d.UserId where d.Id=@Id";
            using (Conn)
            {
                var data = Conn.Query<Demand, User, Demand>(query, (demand, user) => { demand.User = user; return demand; }, new { Id = id });
                return data.FirstOrDefault();
            }
        }


        public Demand GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Demand> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Demand d LEFT JOIN user u on u.Id = d.UserId where " + whereStr + " order by d.DateTime desc";
                }
                else
                {
                    query = "SELECT * FROM Demand d LEFT JOIN user u on u.Id = d.UserId order by d.DateTime desc";
                }
                var data = Conn.Query<Demand, User, Demand>(query, (demand, user) => { demand.User = user; return demand; });

                return data;
            }
        }

        public int UpdateVote(Demand model)
        {
            using (Conn)
            {
                string query = "UPDATE Demand SET Vote=@Vote WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }


    }
}
