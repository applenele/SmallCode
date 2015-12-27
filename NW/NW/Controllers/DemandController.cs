using NW.BLL;
using NW.Entity;
using NW.Entity.DataModels;
using NW.Entity.ViewModels;
using NW.Filter;
using NW.Log4net;
using NW.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NW.Controllers
{
    public class DemandController : BaseController
    {
        // GET: Demand
        //提交我要约首页
        [AutoLog(Description = "我要约首页")]
        public ActionResult Index(int page = 1)
        {
            List<Demand> demands = new List<Demand>();
            List<vDemand> vdemands = new List<vDemand>();
            var query = bllSession.IDemandBLL.GetList("");
            int totalCount = 0;
            PagerHelper.DoPage(ref query, page, 20, ref totalCount);
            foreach (var item in query)
            {
                vdemands.Add(new vDemand(item));
            }
            var demandAsIPagedList = new StaticPagedList<vDemand>(vdemands, page, 20, totalCount);
            return View(demandAsIPagedList);
        }
        //提交我要约要求处理
        [HttpPost]
        [AutoLog(Description = "我要约需求处理")]
        public ActionResult Save(string Title, string Text)
        {
            AjaxModel model = new AjaxModel();
            if (CurrentUser!=null)
            {
                int user_id = CurrentUser.Id;
                Demand demand = new Entity.Demand();
                IBLL.IDemandBLL bll = BLLSessionFactory.GetBLLSession().IDemandBLL;
                User user = new Entity.User();
                user = bllSession.IUserBLL.GetEntity(user_id);
                if(Title.Length==0)
                {
                    model.Statu = "title";
                    model.Data = "请输入标题！";
                    model.Msg = "请输入标题！";
                }
                else if (Title.Length >25)
                {
                    model.Statu = "title";
                    model.Data = "标题过长，请重新输入！";
                    model.Msg = "标题过长，请重新输入！";
                }
                else if (Text.Length == 0)
                {
                    model.Statu = "text";
                    model.Data = "请填写需求！";
                    model.Msg = "请填写需求！";
                }
                bool isBanned=false;
                WordFilterHelper<Demand>.TextFilter(Text,out isBanned);
                if(isBanned)
                {
                    model.Statu = "isBanned";
                    model.Data = "文章内容包含敏感词，请修改后重新提交！";
                }
                else
                {
                    try
                    {
                        demand.Title = Title.Trim();
                        demand.Text = Text.Trim();
                        demand.State = 0;
                        demand.UserId = user_id;
                        demand.DateTime = DateTime.Now;
                        bll.Insert(demand);
                        model.Statu = "ok";
                        model.Msg = "提交成功！";
                        model.BackUrl = "/Demand";
                        log.Info(new LogContent(user.Username + "用户提交需求", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                    }
                    catch (Exception e)
                    {
                        model.Statu = "err";
                        model.Msg = "提交出错请重试！";
                        log.Error(new LogContent(user.Username + "用户提交需求出错" + e.Message, LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                    }
                }
            }
            else
            {
                model.Statu = "go_login";
                model.Msg = "请登录后再提交页面！";
                model.BackUrl = "/User/Login";
            }
            return Json(model);
        }
        //显示我要约详细信息页面
        [HttpGet]
        [AutoLog(Description = "我要约详细信息")]
        public ActionResult Show(int id)
        {
            Demand demand = new Demand();
            demand = bllSession.IDemandBLL.GetEntity(id);
            return View(demand);
        }
        //点赞
        [HttpPost]
        [AutoLog(Description = "我要约点赞")]
        public ActionResult Up_Vote(int Id)
        {
            AjaxModel model = new AjaxModel();
            Demand demand = new Entity.Demand();
            demand = bllSession.IDemandBLL.GetEntity(Id);
            try
            {
                demand.Vote = demand.Vote + 1;
                bllSession.IDemandBLL.Update(demand);
                model.Statu = "ok";
                model.Msg = "提交成功！";
                log.Info(new LogContent("用户点赞", LogType.记录.ToString(), HttpHelper.GetIPAddress()));
            }
            catch(Exception e)
            {
                model.Statu = "err";
                model.Msg = "数据异常，请刷新重试！";
                log.Error(new LogContent("用户点赞出错"+ e.Message, LogType.异常.ToString(), HttpHelper.GetIPAddress()));
            }
            return Json(model);
        }
    }
}