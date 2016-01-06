using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using System.Data;
using NW.Factory;
using Dapper;

namespace NW.DAL
{
    public class ArticleDAL :BaseDAL<Article>, IBaseDAL<Article>, IArticleDAL
    {
        public ArticleDAL()
        {
            base.t = new Article();
        }

        public new Article GetEntity(int id)
        {
            string query = "SELECT * FROM Article a left join User u on a.UserId = u.Id where a.Id = @Id";
            using (Conn)
            {
                var data = Conn.Query<Article, User, Article>(query,(article, user) => { article.User = user; return article; }, new { Id = id });
                return data.FirstOrDefault();
            }
        }

        public Article GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Article> GetList(string whereStr)
        {
            using (Conn)
            {
                string query = "";
                if (!string.IsNullOrEmpty(whereStr))
                {
                    query = "SELECT * FROM Article a left join User u on a.UserId = u.Id  where " + whereStr + "  order by  a.Time desc";
                }
                else
                {
                    query = "SELECT * FROM Article a left join User u on a.UserId = u.Id order by a.Time desc";
                }

                var data = Conn.Query<Article, User, Article>(query, (article, user) => { article.User = user; return article; });
              
                return data;
            }
        }
       
    }
}
