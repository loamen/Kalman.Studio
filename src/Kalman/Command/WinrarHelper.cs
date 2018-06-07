using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Kalman.Command
{
    /// <summary>
    /// 利用Winrar的Dos命令行工具rar.exe压缩解压缩的帮助类
    /// </summary>
    public class WinrarHelper
    {
        string _RarExePath = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rarExePath"></param>
        public WinrarHelper(string rarExePath)
        {
            _RarExePath = rarExePath;
        }

        /// <summary>
        /// 利用rar.exe压缩文件
        /// </summary>
        /// <param name="srcPath">源路径，可以是文件或者文件夹路径</param>
        /// <param name="targetPath">目标路径，压缩后的压缩文件路径</param>
        public void Zip(string srcPath, string targetPath)
        {
            string cmdLine = string.Format("a \"{0}\" \"{1}\" -ep1", targetPath, srcPath);
            Rar(cmdLine);
        }

        /// <summary>
        /// 压缩多个文件
        /// </summary>
        /// <param name="srcFiles">文件路径集合</param>
        /// <param name="targetPath"></param>
        public void Zip(string[] srcFiles, string targetPath)
        {
            string tmpLstFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tmp.lst");
            StringBuilder sb = new StringBuilder();
            foreach (string s in srcFiles)
            {
                sb.Append(s);
                sb.Append("\r\n");
            }
            File.AppendAllText(tmpLstFile, sb.ToString());

            string cmdLine = string.Format("a \"{0}\" \"@{1}\"", targetPath, tmpLstFile);
            Rar(cmdLine);

            File.Delete(tmpLstFile);
        }

        /// <summary>
        /// 利用rar.exe解压文件（覆盖目标文件）
        /// </summary>
        /// <param name="srcPath">要解压缩的压缩文件路径</param>
        /// <param name="targetPath">解压目标文件夹路径</param>
        public void Unzip(string srcPath, string targetPath)
        {
            string cmdLine = string.Format("x \"{0}\" \"{1}\" -o+", srcPath, targetPath);
            Rar(cmdLine);
        }

        /// <summary>
        /// 利用rar.exe压缩解压，执行自定义的压缩解压命令
        /// </summary>
        /// <param name="cmdLine">命令行（不包含rar.exe的路径）</param>
        public void Rar(string cmdLine)
        {
            cmdLine = string.Format("\"{0}\" {1}", _RarExePath, cmdLine);
            CmdHelper.Execute(cmdLine);
        }
    }
}
