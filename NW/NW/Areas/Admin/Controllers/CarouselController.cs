using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class CarouselController : BaseController
    {
        // GET: Admin/Carousel
        public ActionResult Index()
        {
            return View();
        }
    }
}