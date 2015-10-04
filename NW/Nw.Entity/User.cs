using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class User
    {
        public User()
        {
            Articles = new List<Article>();
            Videos = new List<Video>();
        }

        public int Id { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }

        public string Email { set; get; }

        public string Phone { set; get; }

        public string QQ { set; get; }

        public string Address { set; get; }

        public string Remark { set; get; }

        public string Program { set; get; }

        public string Photo { set; get; }

        public int RoleAsInt { set; get; }

        public DateTime Time { set; get; }


        public virtual List<Article> Articles { set; get; }

        public virtual List<Video> Videos { set; get; }

    }

    public enum Role { 一般用户, 会员, 管理员 }
}
