﻿using NW.Entity;
using NW.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class ImageController : BaseController
    {
        // GET: Admin/Image
        public ActionResult Index(string Key)
        {
            string where = "";
            if (!string.IsNullOrEmpty(Key))
            {
                where = where + "Description LIKE '%" + Key + "%'";
            }
            return View(bllSession.IImageBLL.GetList(where).ToPagedList(1, 20));
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                bllSession.IImageBLL.Delete(id);
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }

        /// <summary>
        /// 图片预览
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            Image image = new Image();
            image = bllSession.IImageBLL.GetEntity(id);
            return View(image);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Image model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                try
                {
                    string random = DateHelper.GetTimeStamp();
                    Image image = new Image();
                    image.Title = model.Title;
                    image.Time = DateTime.Now;
                    image.Description = model.Description;
                    string root = "~/Pictures/";
                    var phicyPath = HostingEnvironment.MapPath(root);
                    Directory.CreateDirectory(phicyPath);
                    file.SaveAs(phicyPath + random + Path.GetExtension(file.FileName));
                    image.Path = "/Pictures/" + random + Path.GetExtension(file.FileName);

                    bllSession.IImageBLL.Insert(image);
                    return Redirect("/Admin/Image/Index");
                }
                catch
                {
                    ModelState.AddModelError("", "增加图片出错！");
                }
            }
            else
            {
                ModelState.AddModelError("", "你没有选择图片，请选择图片");
            }
            return View();
        }
    }
}