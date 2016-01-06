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
    public class VideoDAL : BaseDAL<Video>, IVideoDAL
    {

        public VideoDAL()
        {
            base.t = new Video();
        }


        public new Video GetEntity(int id)
        {
            Video video = null;
            string query = "SELECT * FROM Video as v left join Course as c on v.CourseId =c.Id WHERE v.Id = @Id";
            using (Conn)
            {
                video = Conn.Query<Video, Course, Video>(query, (_video, course) =>
                {
                    _video.Course = course;
                    return _video;
                }, new { Id = id }).FirstOrDefault();
            }
            return video;
        }

        public Video GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Video> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(query))
                {
                    query = "SELECT * FROM Video as v left join Course  as c on v.CourseId =c.Id  where " + whereStr + " order by v.Time";
                }
                else
                {
                    query = "SELECT * FROM Video as v left join Course  as c on v.CourseId =c.Id  order by v.Time";
                }
                return Conn.Query<Video, Course, Video>(query, (video, course) =>
                   {
                       video.Course = course;
                       return video;
                   }).Distinct();
            }
        }


        public IEnumerable<Video> GetListByPage(int page, int size, string whereStr)
        {
            int index = size * (page - 1);
            using (Conn)
            {
                string query = "SELECT * FROM Video where " + whereStr + " limit " + index + "," + size;
                return Conn.Query<Video>(query);
            }
        }
    }
}
