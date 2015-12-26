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


        #region 得到Course业务逻辑层
        ICourseBLL iCourseBLL;
        public ICourseBLL ICourseBLL
        {
            get
            {
                if (iCourseBLL == null)
                    iCourseBLL = new CourseBLL();
                return iCourseBLL;
            }
            set
            {
                iCourseBLL = value;
            }
        }
        #endregion

        #region 得到Plateforum业务逻辑层
        IPlateforumBLL iPlateforumBLL;
        public IPlateforumBLL IPlateforumBLL
        {
            get
            {
                if (iPlateforumBLL == null)
                    iPlateforumBLL = new PlateforumBLL();
                return iPlateforumBLL;
            }
            set
            {
                iPlateforumBLL = value;
            }
        }
        #endregion

        #region 得到Replyforum业务逻辑层
        IReplyforumBLL iReplyforumBLL;
        public IReplyforumBLL IReplyforumBLL
        {
            get
            {
                if (iReplyforumBLL == null)
                    iReplyforumBLL = new ReplyforumBLL();
                return iReplyforumBLL;
            }
            set
            {
                iReplyforumBLL = value;
            }
        }
        #endregion


        #region 得到Topicforum业务逻辑层
        ITopicforumBLL iTopicforumBLL;
        public ITopicforumBLL ITopicforumBLL
        {
            get
            {
                if (iTopicforumBLL == null)
                    iTopicforumBLL = new TopicforumBLL();
                return iTopicforumBLL;
            }
            set
            {
                iTopicforumBLL = value;
            }
        }
        #endregion

        #region 得到INotificationBLL业务逻辑层
        INotificationBLL iNotificationBLL;
        public INotificationBLL INotificationBLL
        {
            get
            {
                if (iNotificationBLL == null)
                    iNotificationBLL = new NotificationBLL();
                return iNotificationBLL;
            }
            set
            {
                iNotificationBLL = value;
            }
        }
        #endregion

        #region 得到Sensitive业务逻辑层
        ISensitiveBLL iSensitiveBLL;
        public ISensitiveBLL ISensitiveBLL
        {
            get
            {
                if (iSensitiveBLL == null)
                    iSensitiveBLL = new SensitiveBLL();
                return iSensitiveBLL;
            }
            set
            {
                iSensitiveBLL = value;
            }
        }
        #endregion

        #region 得到Demand业务逻辑层
        IDemandBLL iDemandBLL;
        public IDemandBLL IDemandBLL
        {
            get
            {
                if (iDemandBLL == null)
                    iDemandBLL = new DemandBLL();
                return iDemandBLL;
            }
            set
            {
                iDemandBLL = value;
            }
        }
        #endregion

        #region 得到Carousel业务逻辑层
        ICarouselBLL iCarouselBLL;
        public ICarouselBLL ICarouselBLL
        {
            get
            {
                if (iCarouselBLL == null)
                    iCarouselBLL = new CarouselBLL();
                return iCarouselBLL;
            }
            set
            {
                iCarouselBLL = value;
            }
        }
        #endregion
    }
}
