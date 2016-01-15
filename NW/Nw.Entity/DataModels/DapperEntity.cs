using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity.DataModels
{
    public class DapperDict
    {
        public string Key { set; get; }

        public object Value { set; get; }
    }

    /// <summary>
    /// 两个键值对
    /// </summary>
    public class DapperAddAndUpdateRecord
    {
        public string AddDate { set; get; }

        public object AddCount { set; get; }

        public string UpdateDate { set; get; }

        public object UpdateCount { set; get; }
    }

}
