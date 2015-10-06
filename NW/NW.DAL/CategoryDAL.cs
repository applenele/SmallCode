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
    public class CategoryDAL : IBaseDAL<Category>, ICategoryDAL
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
                string query = "DELETE FROM Category WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Category model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Category WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Category GetEntity(int id)
        {
            Category category;
            string query = "SELECT * FROM Category WHERE Id = @Id";
            using (Conn)
            {
                category = Conn.Query<Category>(query, new { Id = id }).SingleOrDefault();
                return category;
            }
        }

        public Category GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Category where " + whereStr + " order by Time desc";
                }
                else
                {
                    query = "SELECT * FROM Category order by Time desc";
                }

                return Conn.Query<Category>(query);
            }
        }

        public IEnumerable<Category> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Category model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Category(Description,Time)VALUES(@Description,@Time)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Category model)
        {
            using (Conn)
            {
                string query = "UPDATE Category SET  Description=@Description WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
