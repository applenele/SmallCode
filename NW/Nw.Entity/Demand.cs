using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Demand
    {
        public int Id { get; set; }

        public string Title { set; get; }

        public string Text { set; get; }

        public int Vote { set; get; }

        public int UserId { set; get; }

        public virtual User User { set; get; }

        public DateTime DateTime { set; get; }

        public int State { set; get; }

        public DateTime ReviewTime { set; get; }

        public float Price { set; get; }

        public int VideoId { set; get; }

        public Video Video { set; get; }
    }
}
