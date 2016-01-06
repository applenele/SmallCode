using NW.DAL;
using NW.Entity;
using NW.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public class EXArticleBLL : BaseBLL<EXArticle>, IEXArticleBLL
    {
        public override void SetDAL()
        {
            idal = DBSessionFactory.GetDBSession().EXArticleDAL;
        }
    }
}
