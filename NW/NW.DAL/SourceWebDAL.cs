using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using NW.IDAL;
using System.Data;
using NW.Factory;
using Dapper;

namespace NW.DAL
{
    public class SourceWebDAL : BaseDAL<SourceWeb>, ISourceWebDAL
    {
        public SourceWebDAL()
        {
            base.t = new SourceWeb();
        }

        public SourceWeb GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }
    }
}
