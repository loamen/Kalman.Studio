using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Kalman.Utilities
{
    /// <summary>
    /// 网络应用相关工具类
    /// </summary>
    public static class NetUtil
    {
        /// <summary>
        /// 测试指定IP的服务器端口是否打开
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <param name="port">端口</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        public static bool TestIpAndPort(string ip, int port,out string errMsg)
        {
            errMsg = string.Empty;
            IPAddress ipAddress = IPAddress.Parse(ip);
            try
            {
                IPEndPoint point = new IPEndPoint(ipAddress, port);
                TcpClient tcp = new TcpClient(point); 

                return true;
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns>ip地址</returns>
        public static string GetClientIP()
        {
            string result = String.Empty;
            try
            {
                result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(result))
                    result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (string.IsNullOrEmpty(result))
                    result = System.Web.HttpContext.Current.Request.UserHostAddress;

                //可能有代理 
                if (result.IndexOf(".") == -1)     //没有“.”肯定是非IPv4格式 
                    result = string.Empty;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (RegexValidate.IsIP(temparyip[i])
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];     //找到不是内网的地址 
                            }
                        }
                    }
                    else if (RegexValidate.IsIP(result)) //代理即是IP格式 
                        return result;
                    else
                        result = string.Empty;     //代理中的内容 非IP，取IP 
                }
            }
            catch { }
            return result;
        }
    }
}
