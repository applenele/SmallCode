using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { set; get; }


        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { set; get; }

        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateBy { set; get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { set; get; }

        /// <summary>
        /// 修改者
        /// </summary>
        public int? ModifyBy { set; get; }

        /// <summary>
        ///  修改日期
        /// </summary>
        public DateTime? ModifyDate { set; get; }
    }
}
