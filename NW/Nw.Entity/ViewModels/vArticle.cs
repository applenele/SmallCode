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

        [Sensitive]
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
                return NW.Utility.StringHelper.SubString(NW.Utility.StringHelper.CleanHTML(this.Description), 100,
                    "......");
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
