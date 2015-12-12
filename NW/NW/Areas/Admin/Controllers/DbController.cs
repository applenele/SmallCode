using NW.Entity.DataModels;
using NW.Log4net;
using NW.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace NW.Areas.Admin.Controllers
{
    public class DbController : BaseController
    {
        // GET: Admin/Db
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <returns></returns>
        public JsonResult Backup()
        {
            string host = Utility.ConfigurationHelper.GetValue("MysqlHost");
            string port = Utility.ConfigurationHelper.GetValue("MysqlPort");
            string user = Utility.ConfigurationHelper.GetValue("MysqlUser");
            string password = Utility.ConfigurationHelper.GetValue("MysqlPwd");
            string db = Utility.ConfigurationHelper.GetValue("MysqlDb");
            string bakPath = Utility.ConfigurationHelper.GetValue("MysqlBakPath");
            string dumpPath = Utility.ConfigurationHelper.GetValue("MysqlDumpPath");
            var phicyPath = HostingEnvironment.MapPath(bakPath);
            string random = DateHelper.GetTimeStamp();
            if (!Directory.Exists(phicyPath))
            {
                Directory.CreateDirectory(phicyPath);
            }
            bakPath = phicyPath + random + "smallcode.sql";
            //string cmdStr = "mysqldump -h" + host + " -P" + port + " -u" + user + " -p" + password + " " + db + " > " + bakPath;
            StringBuilder sbcommand = new StringBuilder();
            sbcommand.AppendFormat("mysqldump --quick --host=" + host + " --default-character-set=utf8 --lock-tables --verbose  --force --port=" + port + " --user=" + user + " --password=" + password + " " + db + " -r \"{0}\"", bakPath);
            try
            {
                ExecuteCmd(sbcommand.ToString(), dumpPath);
                log.Info(new LogContent(CurrentUser.Username + "备份了数据库" + bakPath, LogType.记录.ToString(), HttpHelper.GetIPAddress()));
                AjaxModel model = new AjaxModel();
                model.Statu = "ok";
                model.Msg = "备份成功！";
                return Json(model);
            }
            catch (Exception ex)
            {
                log.Error(new LogContent(CurrentUser.Username + "备份数据库出错" + ex.Message, LogType.异常.ToString(), HttpHelper.GetIPAddress()));
                AjaxModel model = new AjaxModel();
                model.Statu = "err";
                model.Msg = "备份失败！";
                return Json(model);
            }
        }

        /// <summary>
        /// 通过cmd执行命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="workingDirectory"></param>
        public void ExecuteCmd(string cmd, string workingDirectory)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = workingDirectory;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.WriteLine("exit");
            p.WaitForExit();
        }
    }
}