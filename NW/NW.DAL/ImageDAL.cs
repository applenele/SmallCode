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
    public class ImageDAL : IBaseDAL<Image>, IImageDAL
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
                string query = "DELETE FROM Image WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Image model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Image WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Image GetEntity(int id)
        {
            Image image;
            string query = "SELECT * FROM Image WHERE Id = @Id";
            using (Conn)
            {
                image = Conn.Query<Image>(query, new { Id = id }).SingleOrDefault();
                return image;
            }
        }

        public Image GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Image where " + whereStr + " order by Time desc";
                }
                else
                {
                    query = "SELECT * FROM Image order by Time desc";
                }

                return Conn.Query<Image>(query);
            }
        }

        public IEnumerable<Image> GetListByPage(int page, int size, string whereStr)
        {
            int index = size * (page - 1);
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Article Image " + whereStr + " order by Time desc limit " + index + "," + size;
                }
                else
                {
                    query = "SELECT * FROM Image order by Time desc limit " + index + "," + size;
                }
                return Conn.Query<Image>(query);
            }
        }

        public int Insert(Image model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Image(Title,Description,Path,Time)VALUES(@Title,@Description,@Path,@Time)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Image model)
        {
            using (Conn)
            {
                string query = "UPDATE Image SET  Title=@Title,Description=@Description,Time=@Time,Path=@Path WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
