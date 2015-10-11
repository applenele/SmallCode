using NW.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public class BLLSession
    {
        #region 得到user业务逻辑层
        IUserBLL iUserBLL;
        public IUserBLL IUserBLL
        {
            get
            {
                if (iUserBLL == null)
                    iUserBLL = new UserBLL();
                return iUserBLL;
            }
            set
            {
                iUserBLL = value;
            }
        }
        #endregion


        #region 得到article业务逻辑层
        IArticleBLL iArticleBLL;
        public IArticleBLL IArticleBLL
        {
            get
            {
                if (iArticleBLL == null)
                    iArticleBLL = new ArticleBLL();
                return iArticleBLL;
            }
            set
            {
                iArticleBLL = value;
            }
        }
        #endregion


        #region 得到video业务逻辑层
        IVideoBLL iVideoBLL;
        public IVideoBLL IVideoBLL
        {
            get
            {
                if (iVideoBLL == null)
                    iVideoBLL = new VideoBLL();
                return iVideoBLL;
            }
            set
            {
                iVideoBLL = value;
            }
        }
        #endregion

        #region 得到category业务逻辑层
        ICategoryBLL iCategoryBLL;
        public ICategoryBLL ICategoryBLL
        {
            get
            {
                if (iCategoryBLL == null)
                    iCategoryBLL = new CategoryBLL();
                return iCategoryBLL;
            }
            set
            {
                iCategoryBLL = value;
            }
        }
        #endregion


        #region 得到image业务逻辑层
        IImageBLL iImageBLL;
        public IImageBLL IImageBLL
        {
            get
            {
                if (iImageBLL == null)
                    iImageBLL = new ImageBLL();
                return iImageBLL;
            }
            set
            {
                iImageBLL = value;
            }
        }
        #endregion


        #region 得到log业务逻辑层
        ILogBLL iLogBLL;
        public ILogBLL ILogBLL
        {
            get
            {
                if (iLogBLL == null)
                    iLogBLL = new LogBLL();
                return iLogBLL;
            }
            set
            {
                iLogBLL = value;
            }
        }
        #endregion


        #region 得到reply业务逻辑层
        IReplyBLL iReplyBLL;
        public IReplyBLL IReplyBLL
        {
            get
            {
                if (iReplyBLL == null)
                    iReplyBLL = new ReplyBLL();
                return iReplyBLL;
            }
            set
            {
                iReplyBLL = value;
            }
        }
        #endregion
    }
}
