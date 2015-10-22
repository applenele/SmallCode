using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.IBLL
{
    public interface IBaseBLL<T>
    {
        bool Insert(T model);

        bool Update(T model);

        bool Delete(T model);

        bool Delete(int id);

        IEnumerable<T> GetList(string whereStr);

        T GetEntity(int id);

        T GetEntityWithRefence(int id);

        IEnumerable<T> GetListByPage(int page,int size,string whereStr);
    }
}
