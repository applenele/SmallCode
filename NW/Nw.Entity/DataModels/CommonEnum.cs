using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity.DataModels
{
    public enum LogType { 异常, 记录 }

    /// <summary>
    /// 互联网博客
    /// </summary>
    public enum EXArticleStatus
    {
        显示,
        热门,
        推荐,
        关闭,
        弃用
    }

    public enum EXArticleTempStatus
    {
        未导入,
        导入,
        弃用
    }

    public class CommonString
    {
        public static string[] RoleDisplay = { "一般用户", "会员", "管理员" };
    }
}
