using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Log4net
{
    public class LogContent
    {
        public string Description { set; get; }

        public string Type { set; get; }

        public string Ip { set; get; }

        public LogContent(string Description,string Type, string Ip)
        {
            this.Description = Description;
            this.Ip = Ip;
            this.Type = Type;
        }

        public LogContent() { }
    }
}
