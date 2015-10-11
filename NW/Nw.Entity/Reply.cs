using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Reply
    {
        public int Id { set; get; }

        public int UserId { set; get; }

        public int BlogId { set; get; }

        public string Description { set; get; }

        public int? FatherId { set; get; }

        public DateTime Time { set; get; }

        public virtual User User { set; get; }

        public virtual List<Reply> Children { set; get; }
    }
}
