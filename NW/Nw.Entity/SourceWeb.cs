using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    /// <summary>
    /// 抓取的网站
    /// </summary>
    public class SourceWeb : BaseEntity
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Web { set; get; }

        /// <summary>
        /// 网站网址
        /// </summary>
        public string URL { set; get; }

        /// <summary>
        ///  总共抓取多少片文章
        /// </summary>
        public int Total { set; get; }
    }
}
