using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.IDAL
{
    public interface IBaseDAL<T>
    {
        int Insert(T model);

        int Update(T model);

        int Delete(T model);

        int Delete(int id);

        IEnumerable<T> GetList(string whereStr);

        /// <summary>
        /// 根据主键获得实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntity(int id);

        /// <summary>
        /// 根据主键获得实体以及关联
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityWithRefence(int id);

        IEnumerable<T> GetListByPage(int page,int size,string whereStr,out int total);
    }
}
