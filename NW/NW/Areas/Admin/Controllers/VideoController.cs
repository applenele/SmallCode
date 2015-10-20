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
    public class VideoController : BaseController
    {
        // GET: Admin/Video
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add(int CourseId)
        {
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            Course course = new Course();
            course = bllSession.ICourseBLL.GetEntity(CourseId);
            ViewBag.Course = course;
            return View();
        }

        /// <summary>
        /// 增加视屏教程
        /// </summary>
        /// <param name="file"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(HttpPostedFileBase file, Video model)
        {
            List<Category> categories = bllSession.ICategoryBLL.GetList("").ToList();
            ViewBag.Categories = categories;
            Course course = new Course();
            course = bllSession.ICourseBLL.GetEntity(model.CourseId);
            ViewBag.Course = course;

            if (file != null)
            {
                try
                {
                    string random = DateHelper.GetTimeStamp();
                    string root = "~/Videos/"+model.CourseId+"/";
                    var phicyPath = HostingEnvironment.MapPath(root);
                    Directory.CreateDirectory(phicyPath);
                    file.SaveAs(phicyPath + random + Path.GetExtension(file.FileName));
                    model.Path = "/Videos/"+model.CourseId+"/" + random + Path.GetExtension(file.FileName);
                    model.UserId = CurrentUser.Id;
                    model.Time = DateTime.Now;
                    model.Browses = 0;
                    model.ContentType = file.ContentType;
                    bllSession.IVideoBLL.Insert(model);

                    return Redirect("/Admin/Course/Show/"+model.CourseId);
                }
                catch
                {
                    log.Error(new LogContent("增加视屏出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                    ModelState.AddModelError("", "增加视屏出错！");
                }
            }
            else
            {
                ModelState.AddModelError("", "你没有选择图片，请选择视屏文件");
            }
            return View();
        }


        /// <summary>
        ///  删除视屏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Video video = new Video();
                video = bllSession.IVideoBLL.GetEntity(id);
                var phicyPath = HostingEnvironment.MapPath(video.Path);
                System.IO.File.Delete(phicyPath);
                bool result = bllSession.IVideoBLL.Delete(id);
                if (result)
                {
                    return Content("ok");
                }
                else
                {
                    return Content("err");
                }
            }
            catch
            {
                log.Error(new LogContent("删除视屏出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                return Content("err");
            }
          
        }
    }
}