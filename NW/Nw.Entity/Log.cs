using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Log
    {
        public int Id { set; get; }

        public DateTime Time { set; get; }

        public string Thread { set; get; }

        public string Level { set; get; }

        public string Type { set; get; }

        public string Description { set; get; }

        public string Exception { set; get; }

        public string Ip { set; get; }
    }
}
