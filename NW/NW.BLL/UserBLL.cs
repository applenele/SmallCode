﻿using NW.Entity;
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
        public override void SetDAL()
        {
            idal = DALFactory.GetUserDAL();
        }
    }
}
