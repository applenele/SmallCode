using NW.DAL;
using NW.Entity;
using NW.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public class CategoryDAL : BaseBLL<Category>, ICategoryBLL
    {
        public override void SetDAL()
        {
            idal = DBSessionFactory.GetDBSession().CategoryDAL;
        }
    }
}
