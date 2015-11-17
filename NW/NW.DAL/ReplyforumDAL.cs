using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using System.Data;
using NW.Factory;
using Dapper;

namespace NW.DAL
{
    public class ReplyforumDAL : IBaseDAL<Replyforum>, IReplyforumDAL
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Replyforum model)
        {
            throw new NotImplementedException();
        }

        public Replyforum GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Replyforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Replyforum> GetList(string whereStr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Replyforum> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Replyforum model)
        {
            throw new NotImplementedException();
        }

        public int Update(Replyforum model)
        {
            throw new NotImplementedException();
        }
    }
}
