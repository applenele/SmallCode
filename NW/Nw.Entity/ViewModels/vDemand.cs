using System;
using MarkdownSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity.ViewModels
{
    public class vDemand
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

        //提交时间
        public DateTime DateTime { set; get; }

        //状态，默认为0，0表示讨论中，1表示制作中，2表示完成
        public int State { set; get; }

        //价格
        public float Price { set; get; }

        //课程Id
        public int CourseID { set; get; }

        public string Username { set; get; }

        public vDemand(Demand model)
        {
            Markdown mark = new Markdown();
            this.Id = model.Id;
            this.Title = model.Title;
            this.Text = model.Text;
            this.DateTime = model.DateTime;
            this.Vote = model.Vote;
            this.Price = model.Price;
            this.UserId = model.UserId;
            this.Username = model.User.Username;
            this.State = model.State;
            this.CourseID = model.CourseID;
        }
    }
}
