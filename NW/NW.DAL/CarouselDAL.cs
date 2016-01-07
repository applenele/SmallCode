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
    class CarouselDAL : BaseDAL<Carousel>, IBaseDAL<Carousel>, ICarouselDAL
    {
        public CarouselDAL()
        {
            base.t = new Carousel();
        }

        public new Carousel GetEntity(int id)
        {
            string query = "SELECT * FROM Carousel c LEFT JOIN user u on u.Id = c.CreateBy where c.Id=@Id";
            using (Conn)
            {
                var data = Conn.Query<Carousel, User, Carousel>(query, (carousel, user) => { carousel.User = user; return carousel; }, new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public Carousel GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }
        //不传参数，默认显示没有软删除，可以显示的列表；传参，可以自定义状态
        public new IEnumerable<Carousel> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Carousel where " + whereStr + " order by CreateDate desc";
                }
                else
                {
                    query = "SELECT * FROM Carousel  order by Top desc,CreateDate  desc";
                }

                return Conn.Query<Carousel>(query);
            }
        }

    }
}
