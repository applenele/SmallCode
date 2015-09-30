using NW.Entity;
using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.DAL
{
    public class VideoDAL : IBaseDAL<Video>, IVideoDAL
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Video model)
        {
            throw new NotImplementedException();
        }

        public Video GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Video GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Video> GetList()
        {
            throw new NotImplementedException();
        }

        public int Insert(Video model)
        {
            throw new NotImplementedException();
        }

        public int Update(Video model)
        {
            throw new NotImplementedException();
        }
    }
}
