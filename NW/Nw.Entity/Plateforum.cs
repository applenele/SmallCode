using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    /// <summary>
    /// 论坛板块表
    /// </summary>
    public class Plateforum
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public int Report { get; set; }

        public bool IsClose { get; set; }

        public int Browses { get; set; }
    }
}
