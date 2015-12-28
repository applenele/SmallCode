using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Carousel
    {
        public int Id { get; set; }

        //跳转Url
        public string Href { set; get; }

        //排名
        public int Top { set; get; }

        //简介
        public string Description { set; get; }

        //创建人Id
        public int CreateBy { set; get; }

        //用户实体
        public virtual User User { set; get; }

        //创建时间
        public DateTime CreateDate { set; get; }

        //是否显示状态，默认为1，0表示不显示，1表示显示
        public int IsShow { set; get; }

        //是否删除
        public int IsDelete { set; get; }

        //图片路径
        public string ImagePath { set; get; }
    }
}
