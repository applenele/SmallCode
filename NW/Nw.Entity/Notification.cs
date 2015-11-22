using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    /// <summary>
    /// 通告
    /// </summary>
    public class Notification
    {
        public int ID { set; get; }

        public DateTime CreatedTime { set; get; }

        public string Description { set; get; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { set; get; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { set; get; }
    }
}
