using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Sensitive
    {
        public int Id { get; set; }

        //敏感词名称
        public string Name { set; get; }

        //是否锁定，默认为1,0表示锁定，1表示不锁定
        public int Lock { set; get; }

    }
}
