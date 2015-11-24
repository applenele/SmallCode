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
    public class PlateforumDAL : IBaseDAL<Plateforum>, IPlateforumDAL
    {
        #region   得到数据库连接对象
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
                string query = "DELETE FROM Plateforum WHERE Id=@Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Plateforum model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Plateforum WHERE Id=@Id";
                return Conn.Execute(query, model);
            }
        }

        public Plateforum GetEntity(int id)
        {
            Plateforum plateforum;
            string query = "SELECT * FROM Plateforum WHERE Id=@Id";
            using (Conn)
            {
                plateforum = Conn.Query<Plateforum>(query, new { Id = id }).FirstOrDefault();
                return plateforum;
            }
        }

        public Plateforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plateforum> GetList(string whereStr)
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

        public IEnumerable<Plateforum> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Plateforum model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Plateforum(Title,Picture,Description,Time,Report,IsClose)VALUES(@Title,@Picture,@Description,@Time,@Report,@IsClose)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Plateforum model)
        {
            using (Conn)
            {
                string query = "UPDATE Plateforum SET Title=@Title,Picture=@Picture,Description=@Description,Time=@Time,Report=@Report,IsClose=@IsClose,Browses=@Browses WHERE Id=@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
