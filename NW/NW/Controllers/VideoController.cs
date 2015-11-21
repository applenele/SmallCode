using NW.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class VideoController : BaseController
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  播放视屏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Play(int id)
        {
            Video video = new Video();
            video = bllSession.IVideoBLL.GetEntity(id);
            /// 再此进行 权限的判断
            if (video == null)
            {
                //return Prompt(new Models.Prompt
                //{
                //    Title = "无相关视屏",
                //    Details = "无相关视屏",
                //    HideBack = true,
                //    RedirectUrl="/Home/Index"
                //});

                return Prompt(x => {
                    x.Title = "无相关视屏";
                    x.RedirectUrl = "/Home/Index";
                    x.Details = "无相关视屏";
                });
            }
            video.Browses = video.Browses + 1;
            bllSession.IVideoBLL.Update(video);
            return View(video);
        }
    }
}