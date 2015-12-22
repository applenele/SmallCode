using MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity.ViewModels
{
    public class vForum
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool Top { get; set; }

        public DateTime Time { get; set; }

        public DateTime? LastReply { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int Reward { get; set; }

        public int Browses { get; set; }

        public int Report { get; set; }

        public bool IsShow { get; set; }

        public bool IsClose { get; set; }

        public bool IsOfficeIdentified { get; set; }

        public string Sumamry
        {
            get
            {
                var tmp = Content.Split('\n');
                if (tmp.Count() > 4)
                {
                    var ret = "";
                    for (var i = 0; i < 3; i++)
                    {
                        ret += tmp[i];
                    }
                    ret += "<p>……</p>";
                    return ret;
                }
                else return Content;
            }
        }

        public vForum(Topicforum model)
        {
            Markdown mark = new Markdown();
            this.Id = model.Id;
            this.Title = model.Title;
            this.Content = mark.Transform(model.Content);
            this.Top = model.Top;
            this.Time = model.Time;
            this.LastReply = model.LastReply;
            this.UserId = model.UserId;
            this.Reward = model.Reward;
            this.Browses = model.Browses;
            this.Report = model.Report;
            this.IsShow = model.IsShow;
            this.IsClose = model.IsClose;
            this.IsOfficeIdentified = model.IsOfficeIdentified;


        }
    }
}
