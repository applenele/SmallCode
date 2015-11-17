using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    /// <summary>
    /// 论坛主题表
    /// </summary>
    class Topicforum
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool Top { get; set; }

        public DateTime Time { get; set; }

        public DateTime LastReply { get; set; }

        public int UserId { get; set; }

        public virtual User User{ get; set; }

        public int Reward { get; set; }

        public int Browses { get; set; }

        public int Report { get; set; }

        public bool IsShow { get; set; }

        public bool IsClose { get; set; }

        public bool IsOfficeIdentified { get; set; }
    }
}
