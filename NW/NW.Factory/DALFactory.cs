using NW.DAL;
using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Factory
{
    public class DALFactory
    {
        public DALFactory() { }

        public static readonly IUserDAL  UserDAL = new UserDAL();

        public static readonly IArticleDAL ArticleDAL = new ArticleDAL();

        public static readonly IVideoDAL VideoDAL = new VideoDAL();

        public static IUserDAL GetUserDAL()
        {
            return UserDAL;
        }

        public static IArticleDAL GetArticleDAL()
        {
            return ArticleDAL;
        }

        public static IVideoDAL GetVideoDAL()
        {
            return VideoDAL;
        }
    }
}
