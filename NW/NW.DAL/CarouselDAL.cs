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
    class CarouselDAL : IBaseDAL<Carousel>, ICarouselDAL
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
                string query = "DELETE FROM Carousel WHERE Id = @Id";
                return Conn.Execute(query, new { Id = id });
            }
        }

        public int Delete(Carousel model)
        {
            using (Conn)
            {
                string query = "DELETE FROM Carousel WHERE Id = @Id";
                return Conn.Execute(query, model);
            }
        }

        public Carousel GetEntity(int id)
        {
            string query = "SELECT * FROM Carousel i LEFT JOIN user u on u.Id = d.CreateBy where d.Id=@Id";
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
        public IEnumerable<Carousel> GetList(string whereStr)
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
                    query = "SELECT * FROM Carousel where IsShow=1 and IsDelete=0 order by Top desc";
                }

                return Conn.Query<Carousel>(query);
            }
        }
        public IEnumerable<Carousel> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Carousel model)
        {
            using (Conn)
            {
                string query = "INSERT INTO Carousel(Herf,Description,CreateDate,CreateBy,ImagePath) VALUES(@Herf,@Description,@CreateDate,CreateBy,@ImagePath)";
                return Conn.Execute(query, model);
            }
        }
        public int Update(Carousel model)
        {
            using (Conn)
            {
                string query = "UPDATE Carousel SET Herf=@Herf,Top=@Top,Description=@Description,IsShow=@IsShow,IsDelete=@IsDelete,ImagePath=@ImagePath WHERE Id =@Id";
                return Conn.Execute(query, model);
            }
        }
    }
}
