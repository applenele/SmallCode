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
        public ActionResult Index()
        {
            return View();
        }
    }
}