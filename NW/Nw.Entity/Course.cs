using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Course
    {
        public int  Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public string Category { get; set; }

        public string Cover { get; set; }

        public string Lecturer { set; get; }

        public int Browses { set; get; }
    }
}
