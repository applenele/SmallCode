using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;

namespace NW.Utility
{
    public class WordFilterHelper<T>
    {
        /// <summary>
        /// 内容过滤
        /// </summary>
        /// <param name="body">待过滤内容</param>
        /// <param name="isBanned">是否禁止提交</param>
        public static string TextFilter(string body, out bool isBanned)
        {
            isBanned = false;
            if (string.IsNullOrEmpty(body))
            {
                return body;
            }

            string temBody = body;
            WordFilterStatus staus = WordFilterStatus.Replace;
            temBody = WordFilter.SensitiveWordFilter.Filter(body, out staus);

            if (staus == WordFilterStatus.Banned)
            {
                isBanned = true;
                return body;
            }
            body = temBody;
            return body;
        }

        public static object TextFilter(T model, out bool result)
        {
            result = false;
            Type type = model.GetType();
            PropertyInfo[] PropertyInfos = type.GetProperties();
            foreach (var property in PropertyInfos)
            {
                object[] attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute.GetType() == typeof(SensitiveAttribute))
                    {
                        string val = property.GetValue(model, null).ToString();
                        val = TextFilter(val, out result);
                        property.SetValue(model, val);
                    }
                }
            }
            return model;
        }

        public static object TextFilter(List<T> list, out bool result)
        {
            result = false;
            foreach (T obj in list)
            {
                TextFilter(obj, out result);
            }
            return list;
        }
    }
}
