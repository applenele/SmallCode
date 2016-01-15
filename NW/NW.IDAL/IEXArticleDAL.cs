using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;

namespace NW.IDAL
{
    public interface IEXArticleDAL : IBaseDAL<EXArticle>
    {
        int GetAddRecordsCountByDate(DateTime begin, DateTime end);

        int GetUpdateRecordsCountByDate(DateTime begin, DateTime end);
    }
}
