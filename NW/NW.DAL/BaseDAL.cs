using Dapper;
using NW.Entity.Attribute;
using NW.Entity.DataModels;
using NW.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.DAL
{
    /// <summary>
    ///  继承了BaseEntity的实体 对应的DAL继承此类直接使用
    /// 没有继承的需要自己重写 方法
    /// 因为架构重构了 后期全部改成继承BaseEntity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDAL<T>
    {
        public T t { set; get; }

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

        /// <summary>
        /// 通过id得到对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntity(int id)
        {
            string query = "SELECT * FROM " + t.GetType().Name + " WHERE Id = @Id";
            using (Conn)
            {
                return Conn.Query<T>(query, new { Id = id }).SingleOrDefault();
            }
        }

        /// <summary>
        ///  得到列表
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM " + t.GetType().Name + " where " + whereStr + " order by CreateDate desc";
                }
                else
                {
                    query = "SELECT * FROM " + t.GetType().Name + " order by CreateDate desc";
                }

                return Conn.Query<T>(query);
            }
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public IEnumerable<T> GetListByPage(int page, int size, string whereStr, out int total)
        {
            int index = size * (page - 1);
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = @"SELECT * FROM " + t.GetType().Name + " where " + whereStr + " order by CreateDate desc limit " + index + "," + size +
                        ";select count(1) from " + t.GetType().Name;
                }
                else
                {
                    query = @" SELECT * FROM " + t.GetType().Name + " order by CreateDate desc limit " + index + "," + size +
                        ";select count(1) as total from " + t.GetType().Name;
                }
                var multi = Conn.QueryMultiple(query);
                var result = multi.Read<T>();
                var dapperPage = multi.Read<DapperPage>().AsList()[0];

                total = dapperPage.Total;
                return result;
            }
        }


        #region 删除操作
        /// <summary>
        /// 通过ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string query = "DELETE FROM " + t.GetType().Name + " where Id = @Id";
            using (Conn)
            {
                return Conn.Execute(query, new
                {
                    Id = id
                });
            }
        }

        /// <summary>
        /// 通过对象删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(T model)
        {
            string query = "DELETE FROM " + model.GetType().Name + " where Id = @Id";
            using (Conn)
            {
                return Conn.Execute(query, model);
            }
        }

        #endregion

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(T model)
        {
            StringBuilder query = new StringBuilder("Update " + model.GetType().Name + " set ");
            foreach (System.Reflection.PropertyInfo p in model.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual))
            {
                if (p.Name != "Id")
                {
                    string temp = string.Format("{0}{1}{2}{3}", p.Name, "=", "@", p.Name);
                    query.Append(temp);
                    query.Append(",");
                }
            }
            query.Remove(query.Length - 1, 1);
            query.Append(" where Id = @Id");
            using (Conn)
            {
                return Conn.Execute(query.ToString(), model);
            }
        }

        /// <summary>
        ///  增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(T model)
        {
            StringBuilder keys = new StringBuilder();
            StringBuilder values = new StringBuilder();
            string _sql = "Insert into " + model.GetType().Name + "({0}) values({1})";
            foreach (System.Reflection.PropertyInfo p in model.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual))
            {
                if (p.Name != "Id")
                {
                    keys.Append(p.Name);
                    string temp = string.Format("{0}{1}", "@", p.Name);
                    values.Append(temp);
                    keys.Append(",");
                    values.Append(",");
                }
            }
            keys.Remove(keys.Length - 1, 1);
            values.Remove(values.Length - 1, 1);
            string query = string.Format(_sql, keys, values);
            using (Conn)
            {
                return Conn.Execute(query, model);
            }
        }
    }
}
