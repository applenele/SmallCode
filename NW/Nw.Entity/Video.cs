using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class Video
    {
        public Video()
        {
            User = new User();
            Course = new Course();
        }

        public int Id { set; get; }

        public int CourseId { set; get; }

        public string Title { set; get; }

        public string Category { set; get; }

        public string Path { set; get; }

        public string Seret { set; get; }

        public DateTime Time { set; get; }

        public string Description { set; get; }

        public int UserId { set; get; }

        public int AuthorityAsInt { set; get; }

        public virtual Course Course { set; get; }

        public virtual User User { set; get; }
    }

    public enum Authority { 免费观看, 会员观看 }
}
