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
    public class CourseDAL :BaseDAL<Course>, IBaseDAL<Course>, ICourseDAL
    {
        public CourseDAL()
        {
            base.t = new Course();
        }

        public Course GetEntityWithRefence(int id)
        {
            string query = "SELECT * FROM Course c LEFT JOIN video v on c.Id = v.CourseId where c.Id=@Id";
            Course lookup = null;
            using (Conn)
            {
                var data = Conn.Query<Course,Video,Course>(query,
                    (course,video)=>
                    {
                        if (lookup == null || lookup.Id != course.Id)
                            lookup = course;
                        if (video != null)
                            lookup.Videos.Add(video);
                        return lookup;
                    }
                , new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public new IEnumerable<Course> GetList(string whereStr)
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

       
    }
}
