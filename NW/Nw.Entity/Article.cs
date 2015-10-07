using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Article
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public DateTime Time { set; get; }

        public int Browses { set; get; }

        public string Category { set; get; }

        public int UserId { set; get; }

        public User User { set; get; }
    }
}
