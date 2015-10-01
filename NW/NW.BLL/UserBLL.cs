using NW.DAL;
using NW.Entity;
using NW.Factory;
using NW.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public class UserBLL : BaseBLL<User>, IUserBLL
    {
        public User GetUserByName(string name)
        {
            return DBSessionFactory.GetDBSession().UserDAL.GetUserByName(name);
        }

        public User Login(string username, string password)
        {
            return DBSessionFactory.GetDBSession().UserDAL.Login(username, password);
        }

        public override void SetDAL()
        {
            idal = DBSessionFactory.GetDBSession().UserDAL;
        }
    }
}
