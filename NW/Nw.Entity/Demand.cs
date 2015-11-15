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

        public int UserId { set; get; }

        public virtual User User { set; get; }

        public DateTime DateTime { set; get; }

        public int IsDo { set; get; }

        public DateTime ReviewTime { set; get; }

        public float Price { set; get; }
    }
}
