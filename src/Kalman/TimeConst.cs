using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman
{
    /// <summary>
    /// 时间常量（基础单位：毫秒），可以作为线程等待时间
    /// </summary>
    public static class TimeConst
    {
        /// <summary>
        /// 1毫秒
        /// </summary>
        public static readonly int MS1 = 1;

        /// <summary>
        /// 10毫秒
        /// </summary>
        public static readonly int MS10 = 10;

        /// <summary>
        /// 100毫秒
        /// </summary>
        public static readonly int MS100 = 100;

        /// <summary>
        /// 200毫秒
        /// </summary>
        public static readonly int MS200 = 200;

        /// <summary>
        /// 300毫秒
        /// </summary>
        public static readonly int MS300 = 300;

        /// <summary>
        /// 500毫秒
        /// </summary>
        public static readonly int MS500 = 500;

        /// <summary>
        /// 1秒(=1000毫秒)
        /// </summary>
        public static readonly int S1 = 1000;

        /// <summary>
        /// 2秒(=2000毫秒)
        /// </summary>
        public static readonly int S2 = 2000;

        /// <summary>
        /// 3秒(=3000毫秒)
        /// </summary>
        public static readonly int S3 = 3000;

        /// <summary>
        /// 5秒(=5000毫秒)
        /// </summary>
        public static readonly int S5 = 5000;

        /// <summary>
        /// 10秒(=10000毫秒)
        /// </summary>
        public static readonly int S10 = 10000;

        /// <summary>
        /// 20秒(=20000毫秒)
        /// </summary>
        public static readonly int S20 = 20000;

        /// <summary>
        /// 30秒(=30000毫秒)
        /// </summary>
        public static readonly int S30 = 30000;

        /// <summary>
        /// 1分钟(=60000毫秒)
        /// </summary>
        public static readonly int M1 = 60000;

        /// <summary>
        /// 2分钟(=120000毫秒)
        /// </summary>
        public static readonly int M2 = 120000;

        /// <summary>
        /// 3分钟(=180000毫秒)
        /// </summary>
        public static readonly int M3 = 180000;

        /// <summary>
        /// 5分钟(=300000毫秒)
        /// </summary>
        public static readonly int M5 = 300000;

        /// <summary>
        /// 10分钟(=600000毫秒)
        /// </summary>
        public static readonly int M10 = 600000;

        /// <summary>
        /// 20分钟(=1200000毫秒)
        /// </summary>
        public static readonly int M20 = 1200000;

        /// <summary>
        /// 30分钟(=1800000毫秒)
        /// </summary>
        public static readonly int M30 = 1800000;

        /// <summary>
        /// 1小时(=3600000毫秒)
        /// </summary>
        public static readonly int H1 = 3600000;

        /// <summary>
        /// 2小时(=7200000毫秒)
        /// </summary>
        public static readonly int H2 = 7200000;

        /// <summary>
        /// 3小时(=10800000毫秒)
        /// </summary>
        public static readonly int H3 = 10800000;

        /// <summary>
        /// 5小时(=18000000毫秒)
        /// </summary>
        public static readonly int H5 = 18000000;

        /// <summary>
        /// 10小时(=36000000毫秒)
        /// </summary>
        public static readonly int H10 = 36000000;

        /// <summary>
        /// 1天(=86400000毫秒)
        /// </summary>
        public static readonly int D1 = 86400000;

        /// <summary>
        /// 计算指定秒数对应的毫秒数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int Second2MS(int s)
        {
            return s * S1;
        }

        /// <summary>
        /// 计算指定分钟数对应的毫秒数
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int Minute2MS(int m)
        {
            return m * M1;
        }

        /// <summary>
        /// 计算指定小时数对应的毫秒数
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static int Hour2MS(int h)
        {
            return h * H1;
        }

        /// <summary>
        /// 计算指定天数对应的毫秒数
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int Day2MS(int d)
        {
            return d * D1;
        }
    }
}
