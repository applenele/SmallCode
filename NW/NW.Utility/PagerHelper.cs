using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Utility
{
    public class PagerHelper
    {
        public static void DoPage<T>(ref IEnumerable<T> src, int Page, int PageSize, ref int totalCount)
        {
            totalCount = src.Count();
            src = src.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
