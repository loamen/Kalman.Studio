using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Kalman.Command
{
    /// <summary>
    /// 命令行帮助类
    /// </summary>
    public class CmdHelper
    {
        /// <summary>
        /// 调用cmd.exe执行一条命令
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static string Execute(string cmdText)
        {
            return Execute(new string[] { cmdText });
        }
        
        /// <summary>
        /// 调用cmd.exe执行多条命令
        /// </summary>
        /// <param name="cmdTexts"></param>
        /// <returns></returns>
        public static string Execute(string[] cmdTexts)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string output = null;
            try
            {
                p.Start();

                foreach (string item in cmdTexts)
                {
                    p.StandardInput.WriteLine(item);
                }

                p.StandardInput.WriteLine("exit");
                output = p.StandardOutput.ReadToEnd();
                //strOutput = Encoding.UTF8.GetString(Encoding.Default.GetBytes(strOutput));
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                output = e.Message;
            }

            return output;
        }

        /// <summary>
        /// 启动外部Windows应用程序，隐藏程序界面
        /// </summary>
        /// <param name="appName">应用程序名</param>
        /// <returns></returns>
        public static bool RunApp(string appName)
        {
            return RunApp(appName, ProcessWindowStyle.Hidden);
        }
        
        /// <summary>
        /// 启动外部应用程序
        /// </summary>
        /// <param name="appName">应用程序名</param>
        /// <param name="style">应用程序启动时窗口显示样式</param>
        /// <returns></returns>
        public static bool RunApp(string appName, ProcessWindowStyle style)
        {
            return RunApp(appName, null, style);
        }

        /// <summary>
        /// 启动外部应用程序，隐藏程序界面
        /// </summary>
        /// <param name="appName">应用程序名</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static bool RunApp(string appName, string args)
        {
            return RunApp(appName, args, ProcessWindowStyle.Hidden);
        }
        
        /// <summary>
        /// 启动外部应用程序
        /// </summary>
        /// <param name="appName">应用程序名</param>
        /// <param name="args">参数</param>
        /// <param name="style">应用程序启动时窗口显示样式</param>
        /// <returns></returns>
        public static bool RunApp(string appName, string args, ProcessWindowStyle style)
        {
            bool flag = false;

            Process p = new Process();
            p.StartInfo.FileName = appName;//exe,bat and so on
            p.StartInfo.WindowStyle = style;
            p.StartInfo.Arguments = args;
            try
            {
                p.Start();
                p.WaitForExit();
                p.Close();
                flag = true;
            }
            catch
            {
            }
            return flag;
        }
    }
}
