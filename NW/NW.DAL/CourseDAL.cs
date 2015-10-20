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
    public class CourseDAL : IBaseDAL<Course>, ICourseDAL
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
                string query = "DELETE FROM Course WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Course model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Course WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Course GetEntity(int id)
        {
            string query = "SELECT * FROM Course  where Id=@Id";
            using (Conn)
            {
                var data = Conn.Query<Course>(query, new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public Course GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Course  where " + whereStr + "  order by Time desc";
                }
                else
                {
                    query = "SELECT * FROM Course order by Time desc";
                }

                var data = Conn.Query<Course>(query);

                return data;
            }
        }

        public IEnumerable<Course> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Course model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Course(Title,Description,Time,Browses,Category,Cover,Lecturer)VALUES(@Title,@Description,@Time,@Browses,@Category,@Cover,@Lecturer)";
                return Conn.Execute(query, model);
            }
        }

        public int Update(Course model)
        {
            using (Conn)
            {
                string query = "UPDATE Course SET  Title=@Title,Description=@Description,Browses=@Browses,Category=@Category,Cover=@Cover,Lecturer = @Lecturer WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
