using NW.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.IBLL
{
    public interface IUserBLL:IBaseBLL<User>
    {
        User GetUserByName(string  name);

        User Login(string username, string password);
    }
}
