using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NW.Entity;

namespace NW.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Notification> notifications = new List<Notification>();
            string str = "IsShow = true";
            notifications = bllSession.INotificationBLL.GetList(str).Take(5).ToList();
            List<Carousel> carousels = new List<Carousel>();
            carousels = bllSession.ICarouselBLL.GetList("").Take(5).ToList();
            ViewBag.Notifications = notifications;
            ViewBag.Carousels = carousels;
            ViewBag.CarouselsNum = carousels.Count();
            return View();
        }
    }
}