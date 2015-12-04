using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class DemandController : Controller
    {
        // GET: Demand
        public ActionResult Index()
        {
            List<Demand> demands = new List<Demand>();
            demands = bllSession.IDemandBLL.GetList("").ToList();
            return View(bllSession.IDemandBLL.GetList("").ToPagedList(page,10));
        }
        public ActionResult Push()
        {
            return View();
        }
    }
}