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
    public class VideoDAL : IBaseDAL<Video>, IVideoDAL
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
                string query = "DELETE FROM Video WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Video model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Video WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Video GetEntity(int id)
        {
            Video video;
            string query = "SELECT * FROM Video WHERE Id = @Id";
            using (Conn)
            {
                video = Conn.Query<Video>(query, new { Id = id }).SingleOrDefault();
                return video;
            }
        }

        public Video GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Video> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM Video";
                return Conn.Query<Video>(query).ToList();
            }
        }

        public int Insert(Video model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Video(Title,Description,Time,Browses,Category,UserId,Path,Secret,AuthorityAsInt)VALUES(@Title,@Description,@Time,@Browses,@Category,@UserId,@Path,@Secret,@AuthorityAsInt)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Video model)
        {
            using (Conn)
            {
                string query = "UPDATE User SET Title=@Title,Description=@Description,Time=@Time,Browses=@Browses,Category=@Category,UserId=@UserId,Path=@Path,Secret=@Secret,AuthorityAsInt=@AuthorityAsInt WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }


        public IEnumerable<Video> GetListByPage(int page, int size, string whereStr)
        {
            int index = size * (page - 1);
            using (Conn)
            {
                string query = "SELECT * FROM Video where "+whereStr+" limit " + index + "," + size;
                return Conn.Query<Video>(query);
            }
        }
    }
}
