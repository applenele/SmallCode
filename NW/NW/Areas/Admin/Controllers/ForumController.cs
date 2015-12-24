using NW.Entity;
using NW.Entity.DataModels;
using NW.Log4net;
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
    public class ForumController : BaseController
    {
        // GET: Admin/Forum
        public ActionResult Index(string Key, int page = 1)
        {
            string where = "";
            if (!string.IsNullOrEmpty(Key))
            {
                where = " Title like '%" + Key + "%' ";
            }
            return View(bllSession.IPlateforumBLL.GetList(where).ToPagedList(page, 20));
        }

        #region 板块相关
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        ///  板块增加
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
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
                    plate.Browses = 0;
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

        /// <summary>
        /// 板块展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ForumShow(int id)
        {
            Plateforum plate = new Plateforum();
            plate = bllSession.IPlateforumBLL.GetEntity(id);
            return View(plate);
        }

        /// <summary>
        /// 板块删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeletePlate(int id)
        {
            try
            {
                bllSession.IPlateforumBLL.Delete(id);
                log.Info(new LogContent(CurrentUser.Username + ":删除板块" + id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Content("ok");
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + ":删除板块" + id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                return Content("err");
            }
        }

        /// <summary>
        /// 板块编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    return Redirect("/Admin/Forum/ForumShow/" + model.Id);
                }
                catch (Exception ex)
                {
                    log.Error(new LogContent(CurrentUser.Username + ":修改板块" + model.Id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                }
            }
            return View();
        }

        #endregion

        #region 主题管理
        /// <summary>
        /// 主题管理
        /// </summary>
        /// <param name="id">板块ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TopicManage(int id, string Key, int page = 1)
        {
            string where = "PlateforumId = " + id;
            if (!string.IsNullOrEmpty(Key))
            {
                where = where + " and Title like  '%" + Key + "%' ";
            }
            ViewBag.PlateId = id;
            return View(bllSession.ITopicforumBLL.GetList(where).ToPagedList(page, 20));
        }

        /// <summary>
        /// 主题的增加
        /// </summary>
        /// <param name="id">板块的id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TopicAdd(int id)
        {
            ViewBag.PlateId = id;
            return View();
        }

        /// <summary>
        /// 增加主题
        /// </summary>
        /// <param name="model">主题相关数据</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TopicAdd(Topicforum model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Browses = 0;
                    model.Reward = 1;
                    model.Time = DateTime.Now;
                    model.UserId = CurrentUser.Id;
                    model.Report = 0;
                    bllSession.ITopicforumBLL.Insert(model);
                    log.Info(new LogContent(CurrentUser.Username + ":增加了板块：" + model.PlateforumId + "的主题:" + model.Title, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                    return Redirect("/Admin/Forum/TopicManage/" + model.PlateforumId);
                }
                catch (Exception ex)
                {
                    log.Error(new LogContent(CurrentUser.Username + ":增加了板块：" + model.PlateforumId + "的主题出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                }
            }
            else
            {
                ModelState.AddModelError("", "数据填写错误");
            }
            return View();
        }

        /// <summary>
        /// 删除主题
        /// </summary>
        /// <param name="id">主题ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TopicDelete(int id)
        {
            try
            {
                bllSession.ITopicforumBLL.Delete(id);
                log.Info(new LogContent(CurrentUser.Username + ":删除主题" + id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Content("ok");
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + ":删除主题" + id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                return Content("err");
            }
        }

        /// <summary>
        ///  编辑主题
        /// </summary>
        /// <param name="id">主题ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TopicEdit(int id)
        {
            var topic = bllSession.ITopicforumBLL.GetEntity(id);
            return View(topic);
        }

        /// <summary>
        ///  主题修改
        /// </summary>
        /// <param name="model">主题相关数据</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TopicEdit(Topicforum model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var topic = bllSession.ITopicforumBLL.GetEntity(model.Id);
                    topic.Title = model.Title;
                    topic.Content = model.Content;
                    topic.IsShow = model.IsShow;
                    topic.Top = model.Top;
                    topic.IsClose = model.IsClose;
                    topic.IsOfficeIdentified = model.IsOfficeIdentified;
                    bllSession.ITopicforumBLL.Update(topic);
                    log.Info(new LogContent(CurrentUser.Username + ":修改板块：" + topic.PlateforumId + "的主题:" + model.Title, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                    return Redirect("/Admin/Forum/TopicManage/" + topic.PlateforumId);
                }
                catch (Exception ex)
                {
                    log.Error(new LogContent(CurrentUser.Username + ":修改了板块：" + model.PlateforumId + "的主题出错", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                    ModelState.AddModelError("", "修改板块出错，请重试！");
                }
            }
            else
            {
                ModelState.AddModelError("", "数据填写错误");
            }
            return View();
        }

        /// <summary>
        /// 显示主题详情
        /// </summary>
        /// <param name="id">主题ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TopicDetail(int id)
        {
            var topic = bllSession.ITopicforumBLL.GetEntity(id);
            return View(topic);
        }

        #endregion

        #region 主题回复管理
        /// <summary>
        /// 主题回复管理
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReplyManage(int id, int page = 1)
        {
            ViewBag.TopicId = id;
            return View(bllSession.IReplyforumBLL.GetList("").ToPagedList(page, 20));
        }

        /// <summary>
        /// 删除主题回复
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ReplyDelete(int id)
        {
            try
            {
                bllSession.IReplyforumBLL.Delete(id);
                log.Info(new LogContent(CurrentUser.Username + ":删除主题回复" + id, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Content("ok");
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + ":删除主题回复" + id + "失败", LogType.异常.ToString(), HttpHelper.GetIPAddress()), ex);
                return Content("err");
            }
        }

        /// <summary>
        /// 主题回复批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult ReplyMutiDelete(string ids)
        {
            try
            {
                string[] idsStrArr = ids.Split(',');
                foreach (var id in idsStrArr)
                {
                    bllSession.IReplyforumBLL.Delete(Convert.ToInt32(id));
                }
                log.Info(new LogContent(CurrentUser.Username + "批量删除主题回复" + ids, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                return Content("ok");
            }
            catch (Exception)
            {
                log.Error(new LogContent(CurrentUser.Username + "批量删除主题回复" + ids, LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                throw;
            }
        }

        #endregion
    }
}