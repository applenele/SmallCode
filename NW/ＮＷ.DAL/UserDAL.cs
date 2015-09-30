using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using System.Data;
using NW.Factory;

namespace NW.DAL
{
    public class UserDAL : IBaseDAL<User>, IUserDAL
    {

        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                return _conn = ConnectionFactory.CreateConnection();
            }
        }


        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(User model)
        {
            throw new NotImplementedException();
        }

        public User GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public User GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetList()
        {
            throw new NotImplementedException();
        }

        public int Insert(User model)
        {
            throw new NotImplementedException();
        }

        public int Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
