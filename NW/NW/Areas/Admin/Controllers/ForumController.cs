using NW.Entity;
using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class ForumController : BaseController
    {
        // GET: Admin/Forum
        public ActionResult Index()
        {
            List<Plateforum> plates = new List<Plateforum>();
            plates = bllSession.IPlateforumBLL.GetList("").ToList();
            ViewBag.Plates = plates;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Plateforum model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                try
                {
                    string random = DateHelper.GetTimeStamp();
                    Plateforum plate = new Plateforum();
                    plate.Title = model.Title;
                    plate.Time = DateTime.Now;
                    plate.Description = model.Description;
                    plate.IsClose = model.IsClose;
                    string root = "~/Pictures/";
                    var phicyPath = HostingEnvironment.MapPath(root);
                    if (!Directory.Exists(phicyPath))
                    {
                        Directory.CreateDirectory(phicyPath);
                    }

                    file.SaveAs(phicyPath + random + Path.GetExtension(file.FileName));
                    plate.Picture = "/Pictures/" + random + Path.GetExtension(file.FileName);
                    bllSession.IPlateforumBLL.Insert(plate);

                    log.Info(new LogContent(CurrentUser.Username + "增加了论坛板块", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                    return Redirect("/Admin/Forum/Index");
                }
                catch
                {
                    log.Error(new LogContent("增加板块出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                    ModelState.AddModelError("", "增加板块出错！");
                }
            }
            else
            {
                ModelState.AddModelError("", "你没有选择图片，请选择图片");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ForumShow(int id)
        {
            Plateforum plate = new Plateforum();
            plate = bllSession.IPlateforumBLL.GetEntity(id);
            return View(plate);
        }

        [HttpPost]
        public ActionResult DeletePlate(int id)
        {
            try
            {
                bllSession.IPlateforumBLL.Delete(id);
                log.Info(new LogContent(CurrentUser.Username + ":删除板块"+id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Content("ok");
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + ":删除板块"+id+"失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()),ex);
                return Content("err");
            }
        }

        [HttpGet]
        public ActionResult PlateEdit(int id)
        {
            Plateforum plate = new Plateforum();
            plate = bllSession.IPlateforumBLL.GetEntity(id);
            return View(plate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlateEdit(Plateforum model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Plateforum plate = new Plateforum();
                    plate = bllSession.IPlateforumBLL.GetEntity(model.Id);
                    plate.Title = model.Title;
                    plate.Description = model.Description;
                    plate.IsClose = model.IsClose;

                    if (file != null)
                    {
                        string root = "~/Pictures/";
                        string random = DateHelper.GetTimeStamp();
                        var phicyPath = HostingEnvironment.MapPath(root);
                        var filePath = HostingEnvironment.MapPath(plate.Picture);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        if (!Directory.Exists(phicyPath))
                        {
                            Directory.CreateDirectory(phicyPath);
                        }
                        file.SaveAs(phicyPath + random + Path.GetExtension(file.FileName));
                        plate.Picture = "/Pictures/" + random + Path.GetExtension(file.FileName);
                    }
                    bllSession.IPlateforumBLL.Update(plate);
                    log.Info(new LogContent(CurrentUser.Username + ":修改板块了" + model.Id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                    return Redirect("/Admin/Forum/ForumShow/"+model.Id);
                }
                catch(Exception ex)
                {
                    log.Error(new LogContent(CurrentUser.Username + ":修改板块" + model.Id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                }
            }
            return View();
        }

    }
}