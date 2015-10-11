using NW.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.IBLL
{
    public interface IReplyBLL:IBaseBLL<Reply>
    {
        IEnumerable<Reply> GetReplyAllFather(string whereStr);
    }
}
