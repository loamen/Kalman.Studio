using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Utilities
{
    public sealed class DatetimeUtil
    {
        /// <summary>
        /// 当前系统时间转换为Unix时间戳
        /// </summary>
        /// <returns>Unix时间戳</returns>
        public static Int64 GetCurrentUnixTime()
        {
            return GetUnixTime(DateTime.Now);
        }

        /// <summary>
        /// 系统时间转换为Unix时间戳
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>Unix时间戳</returns>
        public static Int64 GetUnixTime(DateTime dt)
        {
            DateTime unixStartTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan timeSpan = dt.Subtract(unixStartTime);
            string timeStamp = timeSpan.Ticks.ToString();
            return Int64.Parse(timeStamp.Substring(0, timeStamp.Length - 7));
        }

        /// <summary>
        /// Unix时间戳转换为系统时间
        /// </summary>
        /// <param name="unixTimeStamp">Unix时间戳</param>
        /// <returns></returns>
        public static  DateTime GetFromUnixTime(Int64 unixTime)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(unixTime + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 获取指定日期对应的星期中文名，如：星期一
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetWeekCNName(DateTime dt)
        {
            DayOfWeek week = dt.DayOfWeek;
            switch (week)
            {
                case DayOfWeek.Friday:
                    return "星期五";
                case DayOfWeek.Monday:
                    return "星期一";
                case DayOfWeek.Saturday:
                    return "星期六";
                case DayOfWeek.Sunday:
                    return "星期日";
                case DayOfWeek.Thursday:
                    return "星期四";
                case DayOfWeek.Tuesday:
                    return "星期二";
                case DayOfWeek.Wednesday:
                    return "星期三";
            }

            return string.Empty;
        }

    }
}
