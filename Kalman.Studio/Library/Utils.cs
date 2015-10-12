using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Studio
{
    public static class Utils
    {
        public static string DbBooleanValueToStirng(object val)
        {
            if (val == DBNull.Value || val == null) return "";
            return val.ToString();
        }

        public static string DbNumericValueToString(object val)
        {
            if (val == DBNull.Value || val == null) return "";
            return val.ToString();
        }

        public static string DbStringValueToString(object val)
        {
            if (val == DBNull.Value || val == null) return "";
            return val.ToString().Replace("'","''");
        }
    }
}
