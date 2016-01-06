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
    public class ImageDAL : BaseDAL<Image>, IBaseDAL<Image>, IImageDAL
    {
        public ImageDAL()
        {
            base.t = new Image();
        }

        public Image GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Image> GetList(string whereStr)
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

    }
}
