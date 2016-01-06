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
    public class CategoryDAL : BaseDAL<Category>, IBaseDAL<Category>, ICategoryDAL
    {

        public CategoryDAL()
        {
            base.t = new Category();
        }

        public Category GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Category> GetList(string whereStr)
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


    }
}
