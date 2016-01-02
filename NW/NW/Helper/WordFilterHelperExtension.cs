using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Web.Helper
{
    public static class WordFilterHelperExtension
    {
        /// <summary>
        /// 扩展string方法 过滤敏感词
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string ToTextFilter(this string text, out bool result)
        {
            text = WordFilterHelper<object>.TextFilter(text, out result);
            return text;
        }


        /// <summary>
        /// 泛型  对象类型的屏蔽
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T ToTextFilter<T>(this T obj, out bool result)
        {
            T t = WordFilterHelper<T>.TextFilter(obj, out result);
            return t;
        }

        /// <summary>
        ///泛型  列表类型的转换 屏蔽
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToTextFilter<T>(this IEnumerable<T> list, out bool result)
        {
            list = WordFilterHelper<T>.TextFilter(list, out result);
            return list;
        }

       

    }
}
