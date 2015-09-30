using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;

namespace NW.DAL
{
    public class ArticleDAL : IBaseDAL<Article>, IArticleDAL
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Article model)
        {
            throw new NotImplementedException();
        }

        public Article GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Article GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Article> GetList()
        {
            throw new NotImplementedException();
        }

        public int Insert(Article model)
        {
            throw new NotImplementedException();
        }

        public int Update(Article model)
        {
            throw new NotImplementedException();
        }
    }
}
