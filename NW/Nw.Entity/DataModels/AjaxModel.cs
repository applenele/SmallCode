using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity.DataModels
{
    public class AjaxModel
    {
        public object Data { set; get; }
        public string Statu { set; get; }
        public string Msg { set; get; }

        public string BackUrl { set; get; }
    }
}
