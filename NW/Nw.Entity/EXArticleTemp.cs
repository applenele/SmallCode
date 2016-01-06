using NW.Entity.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class EXArticleTemp
    {

        /// <summary>
        ///  主键
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        ///  标题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 来源 网站站点
        /// </summary>
        public string Source { set; get; }

        /// <summary>
        ///  原来的博客的url
        /// </summary>
        public string URL { set; get; }

        /// <summary>
        /// 原来浏览量
        /// </summary>
        public int OldBrowses { set; get; }


        /// <summary>
        /// 分类
        /// </summary>
        public string Category { set; get; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label { set; get; }

        /// <summary>
        /// 原来文章评论数量
        /// </summary>
        public int? ReplyCount { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { set; get; }

        /// <summary>
        ///   时间
        /// </summary>
        public DateTime CreateDate { set; get; }

        /// <summary>
        ///  修改时间
        /// </summary>
        public DateTime? ModifyDate { set; get; }

        /// <summary>
        /// 分词
        /// </summary>
        public string FenCi { set; get; }

        /// <summary>
        /// 状态
        /// </summary>
        public EXArticleTempStatus Status
        {
            set; get;
        }
    }
}
