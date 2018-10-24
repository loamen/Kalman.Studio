using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Kalman.Command
{
    /// <summary>
    /// 命令行帮助类
    /// </summary>
    public class CmdHelper
    {
        /// <summary>
        /// 创建一个批处理文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public static void CreateBat(string fileName,string content)
        {
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            File.WriteAllText(fileName, content, Encoding.Default);   //将s字符串的内容写入v_filepath指定的bat文件中。
        }

        /// <summary>
        /// /调用cmd.exe执行一条命令
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="workingDirectory"></param>
        /// <returns></returns>
        public static string Execute(string cmdText,string workingDirectory = null)
        {
            return Execute(new string[] { cmdText }, workingDirectory);
        }

        /// <summary>
        /// 调用cmd.exe执行多条命令
        /// </summary>
        /// <param name="cmdTexts"></param>
        /// <param name="workingDirectory"></param>
        /// <returns></returns>
        public static string Execute(string[] cmdTexts,string workingDirectory = null)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            if (!string.IsNullOrEmpty(workingDirectory))
            {
                p.StartInfo.WorkingDirectory = workingDirectory;
            }
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
                    if (!string.IsNullOrEmpty(item))
                    {
                        p.StandardInput.WriteLine(item);
                    }
                }
                p.StandardInput.WriteLine("exit");
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit(20 * 1000);
                var ExitCode = p.ExitCode;
               
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
        /// <param name="appName"></param>
        /// <param name="style"></param>
        /// <param name="workingDirectory"></param>
        /// <returns></returns>
        public static bool RunApp(string appName, ProcessWindowStyle style, string workingDirectory)
        {
            return RunApp(appName, null, style, workingDirectory);
        }

        /// <summary>
        /// 启动外部应用程序
        /// </summary>
        /// <param name="appName">应用程序名</param>
        /// <param name="args">参数</param>
        /// <param name="style">应用程序启动时窗口显示样式</param>
        /// <param name="workingDirectory">应用程序启动时窗口显示样式</param>
        /// <returns></returns>
        public static bool RunApp(string appName, string args, ProcessWindowStyle style, string workingDirectory = null)
        {
            bool flag = false;

            Process p = new Process();
            p.StartInfo.FileName = appName;//exe,bat and so on
            p.StartInfo.WindowStyle = style;
            p.StartInfo.Arguments = args;
            if (!string.IsNullOrEmpty(workingDirectory))
            {
                p.StartInfo.WorkingDirectory = workingDirectory;
            }
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
