using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using NW.IDAL;
using Dapper;

namespace NW.DAL
{
    public class EXArticleDAL : BaseDAL<EXArticle>, IEXArticleDAL
    {
        public EXArticleDAL()
        {
            base.t = new EXArticle();
        }

        public EXArticle GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }
    }
}
