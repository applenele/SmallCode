using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using NW.Entity.DataModels;

namespace NW.IDAL
{
    public interface IEXArticleTempDAL : IBaseDAL<EXArticleTemp>
    {
        int GetAddRecordsCountByDate(DateTime begin, DateTime end);

        int GetUpdateRecordsCountByDate(DateTime begin, DateTime end);

        IEnumerable<DapperDict> GetCategoryCount();

        IEnumerable<DapperAddAndUpdateRecord> GetAddAndUpdateRecordsByDate(DateTime begin,DateTime end);
    }
}
