using MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity.ViewModels
{
    public class vArticle
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public DateTime Time { set; get; }

        public int Browses { set; get; }

        public string Category { set; get; }

        public int UserId { set; get; }

        public string Username { set; get; }

        public string Sumamry
        {
            get
            {
                var tmp = Description.Split('\n');
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
                else return Description;
            }
        }

        public vArticle(Article model)
        {
            Markdown mark = new Markdown();
            this.Id = model.Id;
            this.Title = model.Title;
            this.Description = mark.Transform(model.Description);
            this.Time = model.Time;
            this.Browses = model.Browses;
            this.Category = model.Category;
            this.UserId = model.UserId;
            this.Username = model.User.Username;
        }
    }
}
