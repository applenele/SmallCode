using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NW.Entity;
using NW.BLL;

namespace NW.Utility
{
    public static class WordFilterHelper<T>
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

        /// <summary>
        ///将对象对应字段过滤
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isBanned"></param>
        /// <returns></returns>
        public static T TextFilter(T model, out bool isBanned)
        {
            isBanned = false;
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
                        val = TextFilter(val, out isBanned);
                        property.SetValue(model, val);
                    }
                }
            }
            return model;
        }

        /// <summary>
        ///  将集合中对象对应字段过滤
        /// </summary>
        /// <param name="list"></param>
        /// <param name="isBanned"></param>
        /// <returns></returns>
        public static IEnumerable<T> TextFilter(IEnumerable<T> list, out bool isBanned)
        {
            isBanned = false;
            foreach (T obj in list)
            {
                TextFilter(obj, out isBanned);
            }
            return list;
        }



        /// <summary>
        /// 加载敏感词
        /// </summary>
        public static void LoadSensitiveWords()
        {
            BLL.BLLSession bllSession = BLLSessionFactory.GetBLLSession();
            List<Sensitive> words = new List<Sensitive>();
            words = bllSession.ISensitiveBLL.GetList(" `Lock` =0 ").ToList();
            Dictionary<string, string> badWords = new Dictionary<string, string>();
            foreach (var word in words)
            {
                badWords.Add(word.Name, "*");
            }
            WordFilter.Add(1, badWords);
        }
    }
}
