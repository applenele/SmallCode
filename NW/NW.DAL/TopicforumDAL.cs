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
    public class TopicforumDAL : IBaseDAL<Topicforum>, ITopicforumDAL
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Topicforum model)
        {
            throw new NotImplementedException();
        }

        public Topicforum GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Topicforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topicforum> GetList(string whereStr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topicforum> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Topicforum model)
        {
            throw new NotImplementedException();
        }

        public int Update(Topicforum model)
        {
            throw new NotImplementedException();
        }
    }
}
