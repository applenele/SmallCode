using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Image
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public string Path { set; get; }

        public DateTime Time { set; get; }

        /// <summary>
        ///  对应主题的ID
        /// </summary>
        public int? ImageThemeId { set; get; }
    }
}
