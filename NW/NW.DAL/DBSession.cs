﻿using NW.IDAL;
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



        #region IImageDAL
        IImageDAL iImageDAL;
        public IImageDAL ImageDAL
        {
            get
            {
                if (iImageDAL == null)
                    iImageDAL = new ImageDAL();
                return iImageDAL;
            }
            set
            {
                iImageDAL = value;
            }
        }
        #endregion

        #region ILogDAL
        ILogDAL iLogDAL;
        public ILogDAL LogDAL
        {
            get
            {
                if (iLogDAL == null)
                    iLogDAL = new LogDAL();
                return iLogDAL;
            }
            set
            {
                iLogDAL = value;
            }
        }
        #endregion

        #region IReplyDAL
        IReplyDAL iReplyDAL;
        public IReplyDAL ReplyDAL
        {
            get
            {
                if (iReplyDAL == null)
                    iReplyDAL = new ReplyDAL();
                return iReplyDAL;
            }
            set
            {
                iReplyDAL = value;
            }
        }
        #endregion



        #region iCourseDAL
        ICourseDAL iCourseDAL;
        public ICourseDAL CourseDAL
        {
            get
            {
                if (iCourseDAL == null)
                    iCourseDAL = new CourseDAL();
                return iCourseDAL;
            }
            set
            {
                iCourseDAL = value;
            }
        }
        #endregion

        #region iPlateforumDAL
        IPlateforumDAL iPlateforumDAL;
        public IPlateforumDAL PlateforumDAL
        {
            get
            {
                if (iPlateforumDAL == null)
                    iPlateforumDAL = new PlateforumDAL();
                return iPlateforumDAL;
            }
            set
            {
                iPlateforumDAL = value;
            }
        }
        #endregion


        #region iReplyforumDAL
        IReplyforumDAL iReplyforumDAL;
        public IReplyforumDAL ReplyforumDAL
        {
            get
            {
                if (iReplyforumDAL == null)
                    iReplyforumDAL = new ReplyforumDAL();
                return iReplyforumDAL;
            }
            set
            {
                iReplyforumDAL = value;
            }
        }
        #endregion


        #region iTopicforumDAL
        ITopicforumDAL iTopicforumDAL;
        public ITopicforumDAL TopicforumDAL
        {
            get
            {
                if (iTopicforumDAL == null)
                    iTopicforumDAL = new TopicforumDAL();
                return iTopicforumDAL;
            }
            set
            {
                iTopicforumDAL = value;
            }
        }
        #endregion

        #region INotificationDAL
        INotificationDAL iNotificationDAL;
        public INotificationDAL NotificationDAL
        {
            get
            {
                if (iNotificationDAL == null)
                    iNotificationDAL = new NotificationDAL();
                return iNotificationDAL;
            }
            set
            {
                iNotificationDAL = value;
            }
        }
        #endregion

        #region iDemandDAL
        IDemandDAL iDemandDAL;
        public IDemandDAL DemandDAL
        {
            get
            {
                if (iDemandDAL == null)
                    iDemandDAL = new DemandDAL();
                return iDemandDAL;
            }
            set
            {
                iDemandDAL = value;
            }
        }
        #endregion

        #region iSensitiveDAL
        ISensitiveDAL iSensitiveDAL;
        public ISensitiveDAL SensitiveDAL
        {
            get
            {
                if (iSensitiveDAL == null)
                    iSensitiveDAL = new SensitiveDAL();
                return iSensitiveDAL;
            }
            set
            {
                iSensitiveDAL = value;
            }
        }
        #endregion

        #region iCarouselDAL
        ICarouselDAL iCarouselDAL;
        public ICarouselDAL CarouselDAL
        {
            get
            {
                if (iCarouselDAL == null)
                    iCarouselDAL = new CarouselDAL();
                return iCarouselDAL;
            }
            set
            {
                iCarouselDAL = value;
            }
        }
        #endregion

        #region iEXArticleDAL
        IEXArticleDAL iEXArticleDAL;
        public IEXArticleDAL EXArticleDAL
        {
            get
            {
                if (iEXArticleDAL == null)
                    iEXArticleDAL = new EXArticleDAL();
                return iEXArticleDAL;
            }
            set
            {
                iEXArticleDAL = value;
            }
        }
        #endregion

        #region iEXArticleTempDAL
        IEXArticleTempDAL iEXArticleTempDAL;
        public IEXArticleTempDAL EXArticleTempDAL
        {
            get
            {
                if (iEXArticleTempDAL == null)
                    iEXArticleTempDAL = new EXArticleTempDAL();
                return iEXArticleTempDAL;
            }
            set
            {
                iEXArticleTempDAL = value;
            }
        }
        #endregion

        #region iSourceWebDAL
        ISourceWebDAL iSourceWebDAL;
        public ISourceWebDAL SourceWebDAL
        {
            get
            {
                if (iSourceWebDAL == null)
                    iSourceWebDAL = new SourceWebDAL();
                return iSourceWebDAL;
            }
            set
            {
                iSourceWebDAL = value;
            }
        }
        #endregion
    }
}
