using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.Utility
{
    public static class ConfigurationHelper
    {
        public static string GetValue(string key)
        {
            return   ConfigurationManager.AppSettings[key];
        }
    }
}
