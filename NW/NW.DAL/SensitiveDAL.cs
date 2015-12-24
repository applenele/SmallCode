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
    class SensitiveDAL : IBaseDAL<Sensitive>, ISensitiveDAL
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
                string query = "DELETE FROM Sensitive WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Sensitive model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Sensitive WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Sensitive GetEntity(int id)
        {
            Sensitive Sensitive;
            string query = "SELECT * FROM Sensitive WHERE Id = @Id";
            using (Conn)
            {
                Sensitive = Conn.Query<Sensitive>(query, new { Id = id }).SingleOrDefault();
                return Sensitive;
            }
        }

        public Sensitive GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensitive> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Sensitive where " + whereStr + " order by Name desc";
                }
                else
                {
                    query = "SELECT * FROM Sensitive order by Name desc";
                }

                return Conn.Query<Sensitive>(query);
            }
        }
        public IEnumerable<Sensitive> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Sensitive model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Sensitive(Name,Lock) VALUES(@Name,1)";
                return Conn.Execute(query, model);
            }
        }
        public int Update(Sensitive model)
        {
            using (Conn)
            {
                string query = "UPDATE Sensitive SET Name=@Name,Lock=@Lock WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
