using NW.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.IBLL
{
    public interface IEXArticleBLL:IBaseBLL<EXArticle>
    {
        int GetAddRecordsCountByDate(DateTime begin, DateTime end);

        int GetUpdateRecordsCountByDate(DateTime begin, DateTime end);
    }
}
