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
    public class UserDAL : IBaseDAL<User>, IUserDAL
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

        public int Insert(User model)
        {
            using (Conn)
            {
                string query = "INSERT INTO User(Username,Password,Email,Phone,QQ,Address,Remark,Program,Photo,RoleAsInt,Time)VALUES(@Username,@Password,@Email,@Phone,@QQ,@Address,@Remark,@Program,@Photo,@RoleAsInt,@Time)";
                return Conn.Execute(query, model);
            }
        }


        public int Delete(int id)
        {
            using (Conn)
            {
                string query = "DELETE FROM User WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }


        public int Delete(User model)
        {
            using (Conn)
            {
                string query = "DELETE FROM User WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public int Update(User model)
        {
            using (Conn)
            {
                string query = "UPDATE User SET  Username=@Username,Password=@Password,Email=@Email,Phone=@Phone,QQ=@QQ,Address=@Address,Remark=@Remark,Program=@Program,Photo=@Photo,RoleAsInt = @RoleAsInt,Time=@Time WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }

        public User GetEntity(int id)
        {
            User user;
            string query = "SELECT * FROM User WHERE Id = @Id";
            using (Conn)
            {
                user = Conn.Query<User>(query, new { Id = id }).SingleOrDefault();
                return user;
            }
        }

        public User GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM User";
                return Conn.Query<User>(query).ToList();
            }
        }

        /// <summary>
        /// 根据用户名得到用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            using (Conn)
            {
                string query = "SELECT * FROM User where Username=@Username";
                return Conn.Query<User>(query, new { Username = name }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string username, string password)
        {
            using (Conn)
            {
                string query = "SELECT * FROM User where Username=@Username and Password = @Password";
                return Conn.Query<User>(query, new { Username = username, Password = password }).FirstOrDefault();
            }
        }
    }
}
