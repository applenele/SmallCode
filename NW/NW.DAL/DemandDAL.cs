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
    class DemandDAL : IBaseDAL<Demand>, IDemandDAL
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
                string query = "DELETE FROM Demand WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Demand model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Demand WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Demand GetEntity(int id)
        {
            Demand Demand;
            string query = "SELECT * FROM Demand WHERE Id = @Id";
            using (Conn)
            {
                Demand = Conn.Query<Demand>(query, new { Id = id }).SingleOrDefault();
                return Demand;
            }
        }

        public Demand GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Demand> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Demand where " + whereStr + " order by DateTime desc";
                }
                else
                {
                    query = "SELECT * FROM Demand order by DateTime desc";
                }

                return Conn.Query<Demand>(query);
            }
        }
        public IEnumerable<Demand> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Demand model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Demand(UserId,DateTime,State) VALUES(@UserId,@DateTime,0)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Demand model)
        {
            using (Conn)
            {
                string query = "UPDATE Demand SET State=@State,Price=@Price,ReviewTime=@ReviewTime,@VideoId WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
