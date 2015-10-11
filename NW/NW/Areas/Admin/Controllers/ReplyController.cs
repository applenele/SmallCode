using NW.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class ReplyController : BaseController
    {
        // GET: Admin/Reply
        public ActionResult Index(int page =1)
        {
            return View(bllSession.IReplyBLL.GetReplyAllFather("").ToPagedList(page,20));
        }

        public ActionResult Show(int id)
        {
            Reply reply = bllSession.IReplyBLL.GetEntity(id);
            return View(reply);
        }
    }
}