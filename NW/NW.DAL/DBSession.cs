using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.DAL
{
    public class DBSession
    {
        #region 得到数据库访问层UserDAL
        IUserDAL iUserDAL;
        public IUserDAL UserDAL
        {
            get
            {
                if (iUserDAL == null)
                    iUserDAL = new UserDAL();
                return iUserDAL;
            }
            set
            {
                iUserDAL = value;
            }
        }
        #endregion

        #region  得到数据库访问层AricleDAL
        IArticleDAL iArticleDAL;
        public IArticleDAL ArticleDAL
        {
            get
            {
                if (iArticleDAL == null)
                    iArticleDAL = new ArticleDAL();
                return iArticleDAL;
            }
            set
            {
                iArticleDAL = value;
            }
        }
        #endregion

        #region 得到数据库访问层VideoDAL
        IVideoDAL iVideoDAL;
        public IVideoDAL VideoDAL
        {
            get
            {
                if (iVideoDAL == null)
                    iVideoDAL = new VideoDAL();
                return iVideoDAL;
            }
            set
            {
                iVideoDAL = value;
            }
        }
        #endregion


        #region ICategoryDAL
        ICategoryDAL iCategoryDAL;
        public ICategoryDAL CategoryDAL
        {
            get
            {
                if (iCategoryDAL == null)
                    iCategoryDAL = new CategoryDAL();
                return iCategoryDAL;
            }
            set
            {
                iCategoryDAL = value;
            }
        }
        #endregion



    }
}
