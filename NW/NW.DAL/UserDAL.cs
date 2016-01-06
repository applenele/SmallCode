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
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        public UserDAL()
        {
            base.t = new User();
        }


        public User GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<User> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM User where " + whereStr + " order by Time";
                }
                else
                {
                    query = "SELECT * FROM User order by Time";
                }
                return Conn.Query<User>(query);
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
                string query = "SELECT * FROM User where Username = @Username";
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
                string query = "SELECT * FROM User where Username = @Username and Password = @Password";
                return Conn.Query<User>(query, new { Username = username, Password = password }).FirstOrDefault();
            }
        }


        /// <summary>
        /// 根据邮箱获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            using (Conn)
            {
                string query = "SELECT * FROM User where Email = @Email";
                return Conn.Query<User>(query, new { Email = email }).FirstOrDefault();
            }
        }
    }
}
