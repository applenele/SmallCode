using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Demand
    {
        public int Id { get; set; }

        //标题
        public string Title { set; get; }

        //内容
        public string Text { set; get; }

        //投票数
        public int Vote { set; get; }

        //用户id
        public int UserId { set; get; }

        //用户实体
        public virtual User User { set; get; }

        //提交时间
        public DateTime DateTime { set; get; }

        //状态，默认为0，0表示讨论中，1表示制作中，2表示完成
        public int State { set; get; }

        //审查时间
        public DateTime ReviewTime { set; get; }

        //价格
        public float Price { set; get; }

        //课程Id
        public int CourseID { set; get; }

        //课程实体
        public Course Course { set; get; }
    }
}
