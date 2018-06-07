using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Kalman.Utilities
{
    /// <summary>
    /// 反射工具类
    /// </summary>
    public class ReflectUtil
    {
        /// <summary>
        /// 从当前应用程序域中根据类型名称查找该类型所属的程序集
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Assembly FindAssemblyFromCurrentAppDomain(string typeName)
        {
            AppDomain appDomain = AppDomain.CurrentDomain;
            return FindAssemblyFromAppDomain(appDomain, typeName);
        }

        /// <summary>
        /// 从指定应用程序域中根据类型名称查找该类型所属的程序集
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Assembly FindAssemblyFromAppDomain(AppDomain appDomain, string typeName)
        {
            Assembly[] assemblies = appDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.FullName == typeName)
                        return assembly;
                }
            }
            return null;
        }

        /// <summary>
        /// 从应用程序根目录的文件中根据类型名称查找该类型所属的程序集
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Assembly FindAssemblyFromAppDirectory(string typeName)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string binPath = Path.Combine(rootPath, "bin");
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            FileInfo[] files;
            files = dir.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.FullName == typeName)
                        return assembly;
                }
            }

            if (Directory.Exists(binPath) == false)
            {
                binPath = rootPath;
            }

            dir = new DirectoryInfo(binPath);
            files = dir.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in files)
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.FullName == typeName)
                        return assembly;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取当前正在执行的方法信息，如：ClassName->Method(arg1,arg2,out arg3)
        /// </summary>
        /// <param name="skipFrames">堆栈上要跳过的帧数，直接调用该方法为1，间接调用请再加上封装的层次</param>
        /// <returns></returns>
        public static string GetCurrentMethodInfo(int skipFrames)
        {
            StackFrame f = new StackFrame(skipFrames, true);  //调用日志记录器的类所在的堆栈帧
            int lineNum = f.GetFileLineNumber();
            MethodBase method = f.GetMethod();
            Type classType = method.ReflectedType;

            StringBuilder sb = new StringBuilder(string.Format("{0}->{1}", classType.FullName, method.Name));
            if (method.IsGenericMethod)
            {
                Type[] ts = method.GetGenericArguments();
                sb.Append("<");
                for (int i = 0; i < ts.Length; i++)
                {
                    sb.Append(ts[i].Name);
                    if (i != ts.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(">");
            }

            ParameterInfo[] ps = method.GetParameters();

            sb.Append("(");
            for (int i = 0; i < ps.Length; i++)
            {
                ParameterInfo p = ps[i];
                if (p.IsOut)
                {
                    sb.Append("out " + p.Name);
                }
                else
                {
                    sb.Append(p.Name);
                }

                if (i != ps.Length - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append(") at line" + lineNum);
            return sb.ToString();

        }
    }
}
