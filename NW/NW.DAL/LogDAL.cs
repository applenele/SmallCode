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
using NW.Entity.DataModels;

namespace NW.DAL
{
    public class LogDAL : BaseDAL<Log>, ILogDAL
    {

        public int Delete(int id)
        {
            using (Conn)
            {
                string query = "DELETE FROM Log WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Log model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Log WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Log GetEntity(int id)
        {
            Log log;
            string query = "SELECT * FROM Log WHERE Id = @Id";
            using (Conn)
            {
                log = Conn.Query<Log>(query, new { Id = id }).SingleOrDefault();
                return log;
            }
        }

        public Log GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Log> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Log where " + whereStr + " order by Time desc";
                }
                else
                {
                    query = "SELECT * FROM Log order by Time desc";
                }

                return Conn.Query<Log>(query);
            }
        }

        public new IEnumerable<Log> GetListByPage(int page, int size, string whereStr, out int total)
        {
            int index = size * (page - 1);
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Log where " + whereStr + " order by Time desc limit " + index + "," + size + ";select count(1) as total from Log";
                }
                else
                {
                    query = "SELECT * FROM Log order by Time desc limit " + index + "," + size + ";select count(1) as total from Log";
                }
                var multi = Conn.QueryMultiple(query);
                var result = multi.Read<Log>();
                var dapperPage = multi.Read<DapperPage>().AsList()[0];

                total = dapperPage.Total;
                return result;
            }
        }

        public new int Insert(Log model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Log (Time,Thread,Level,Type,Description,Exception,Ip) VALUES (@Time,@Thread,@Level,@Type,@Description,@Exception,@Ip)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Log model)
        {
            using (Conn)
            {
                string query = "UPDATE Log SET  Time=@Time,Thread=@Thread,Level=@Level,Type=@Type,Description=@Description,Exception=@Exception,Ip=@Ip WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
