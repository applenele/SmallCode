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
    public class PlateforumDAL : IBaseDAL<Plateforum>, IPlateforumDAL
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Plateforum model)
        {
            throw new NotImplementedException();
        }

        public Plateforum GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Plateforum GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plateforum> GetList(string whereStr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plateforum> GetListByPage(int page, int size, string whereStr)
        {
            throw new NotImplementedException();
        }

        public int Insert(Plateforum model)
        {
            throw new NotImplementedException();
        }

        public int Update(Plateforum model)
        {
            throw new NotImplementedException();
        }
    }
}
