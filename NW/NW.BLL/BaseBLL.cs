using NW.IBLL;
using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        public BaseBLL()
        {
            SetDAL();
        }

        protected IBaseDAL<T> idal;

        public abstract void SetDAL();

        public bool Delete(int id)
        {
            return idal.Delete(id) > 0 ? true : false;
        }

        public bool Delete(T model)
        {
            return idal.Delete(model) > 0 ? true : false;
        }

        public IEnumerable<T> GetList(string whereStr)
        {
            return idal.GetList(whereStr);
        }

        public T GetEntity(int id)
        {
            return idal.GetEntity(id);
        }

        public T GetEntityWithRefence(int id)
        {
            return idal.GetEntityWithRefence(id);
        }

        public bool Insert(T model)
        {
            return idal.Insert(model) > 0 ? true : false;
        }

        public bool Update(T model)
        {
            return idal.Update(model) > 0 ? true : false;
        }

        public IEnumerable<T> GetListByPage(int page, int size,string whereStr)
        {
            return idal.GetListByPage(page, size,whereStr);
        }
    }
}
