using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    /// <summary>
    /// 论坛回复表
    /// </summary>
    class Replyforum
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public virtual Topicforum Topicforum { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int FatherId { get; set; }
    }
}
