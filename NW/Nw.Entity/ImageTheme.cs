using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class ImageTheme : BaseEntity
    {
        public string Title { set; get; }

        public string Description { set; get; }

        public string Url { set; get; }

        public string Source { set; get; }
    }
}
