using NW.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Course
        public ActionResult Index(int page=1)
        {
            List<Course> courses = new List<Course>();
            courses = bllSession.ICourseBLL.GetList("").ToList();
            return View(bllSession.ICourseBLL.GetList("").ToPagedList(page,10));
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            Course course = new Course();
            course = bllSession.ICourseBLL.GetEntityWithRefence(id);
            return View(course);
        }
    }
}