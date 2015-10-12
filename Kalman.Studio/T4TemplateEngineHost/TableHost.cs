using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.CodeDom.Compiler;
using Kalman.Data.SchemaObject;
using Kalman.Utilities;

namespace Kalman.Studio.T4TemplateEngineHost
{
    /// <summary>
    /// T4模板处理引擎，提供数据库表的架构数据
    /// </summary>
    [Serializable]
    public class TableHost : HostBase, ITextTemplatingEngineHost
    {
        /// <summary>
        /// 表信息
        /// </summary>
        public SOTable Table { get; set; }

        List<SOColumn> _ColumnList;
        public List<SOColumn> ColumnList
        {
            get
            {
                if (_ColumnList == null) return Table.ColumnList;
                return _ColumnList;
            }
            set { _ColumnList = value; }
        }

        #region ITextTemplatingEngineHost

        CompilerErrorCollection _ErrorCollection;
        /// <summary>
        /// 模板引擎主机处理模板时错误信息集合
        /// </summary>
        public CompilerErrorCollection ErrorCollection
        {
            get { return _ErrorCollection; }
        }

        string _FileExtention = ".cs";
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtention { get { return _FileExtention; } set { _FileExtention = value; } }

        Encoding _FileEncoding = Encoding.UTF8;
        /// <summary>
        /// 文件编码
        /// </summary>
        public Encoding FileEncoding { get { return _FileEncoding; } }

        #endregion

        #region ITextTemplatingEngineHost 成员

        /// <summary>
        /// 通过不同的optionName获取相应的Host数据（可以不实现该方法）
        /// </summary>
        /// <param name="optionName"></param>
        /// <returns></returns>
        public object GetHostOption(string optionName)
        {
            object returnObject = null;
            //根据选项名称来获取数据
            switch (optionName)
            {
                case "CacheAssemblies":
                    returnObject = true;
                    break;
                default:
                    break;
            }
            return returnObject;
        }

        /// <summary>
        /// 加载文件中包含的文本（可以不实现该方法）
        /// The engine calls this method based on the optional include directive if the user has specified it in the text template.This method can be called 0, 1, or more times.
        /// 该引擎调用可选include指令，如果用户指定了在文本template.This方法，它可以被调用0次，1次或更多次此方法。
        /// If the host searches the registry for the location of include files or if the host searches multiple locations by default, the host can return the final path of the include file in the location parameter.
        /// 如果主机搜索的位置的注册表包含文件或主机搜查多个地点，默认情况下，主机可以返回包含文件中的位置参数的最终路径。
        /// </summary>
        /// <param name="requestFileName">请求的文件名（包含路径）</param>
        /// <param name="content">文本内容</param>
        /// <param name="location">位置？</param>
        /// <returns>文件加载成功则返回true</returns>
        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
            content = System.String.Empty;
            location = System.String.Empty;

            if (File.Exists(requestFileName))
            {
                content = File.ReadAllText(requestFileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 记录错误信息
        /// The engine calls this method when it is done processing a text template to pass any errors that occurred to the host. The host can decide how to display them.
        /// 该引擎调用完成时，处理文本模板通过任何错误发生的主机此方法。主机可以决定如何显示它们。
        /// </summary>
        /// <param name="errors"></param>
        public void LogErrors(System.CodeDom.Compiler.CompilerErrorCollection errors)
        {
            _ErrorCollection = errors;
        }

        /// <summary>
        /// 提供处理模板的应用程序域
        /// This is the application domain that is used to compile and run the generated transformation class to create the generated text output.
        /// 该应用程序域用于编译和运行生成的类来创建转换生成的文本输出。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public AppDomain ProvideTemplatingAppDomain(string content)
        {
            //This host will provide a new application domain each time the engine processes a text template.
            //该主机将提供一个新的应用程序域每次引擎处理文本模板。
            return AppDomain.CreateDomain("Generation App Domain");

            //This could be changed to return the current appdomain, but new 
            //assemblies are loaded into this AppDomain on a regular basis.
            //If the AppDomain lasts too long, it will grow indefintely, 
            //which might be regarded as a leak.

            //This could be customized to cache the application domain for 
            //a certain number of text template generations (for example, 10).

            //This could be customized based on the contents of the text 
            //template, which are provided as a parameter for that purpose.
        }

        /// <summary>
        /// 解析程序集引用
        /// The engine calls this method to resolve assembly references used in the generated transformation class project and for the optional assembly directive if the user has specified it in the text template. This method can be called 0, 1, or more times.
        /// 该引擎调用此方法来解决在生成的改造类项目所使用的程序集引用和可选的指令集，如果用户在文本中指定它的模板。这种方法可调用0，1次或多次。
        /// </summary>
        /// <param name="assemblyReference">程序集引用路径</param>
        /// <returns></returns>
        public string ResolveAssemblyReference(string assemblyReference)
        {
            //完全路径
            if (File.Exists(assemblyReference))
            {
                return assemblyReference;
            }

            //和模板文件在同一目录
            string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), assemblyReference);
            if (File.Exists(candidate))
            {
                return candidate;
            }

            //不属于前两种情况的话，返回空字符串
            return string.Empty;
        }

        /// <summary>
        /// 模板引擎在用户指定文本模板指令的基础上调用该方法，该方法可以调用0，1次或多次
        /// </summary>
        /// <param name="processorName"></param>
        /// <returns></returns>
        public Type ResolveDirectiveProcessor(string processorName)
        {
            //This host will not resolve any specific processors.

            //Check the processor name, and if it is the name of a processor the 
            //host wants to support, return the type of the processor.
            //---------------------------------------------------------------------
            if (string.Compare(processorName, "XYZ", StringComparison.OrdinalIgnoreCase) == 0)
            {
                //return typeof();
            }

            //This can be customized to search specific paths for the file
            //or to search the GAC

            //If the directive processor cannot be found, throw an error.
            throw new Exception("没有找到指令处理器");
        }

        /// <summary>
        /// If a call to a directive in a text template does not provide a value for a required parameter, the directive processor can try to get it from the host by calling this method.
        /// </summary>
        /// <param name="directiveId"></param>
        /// <param name="processorName"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
        {
            if (directiveId == null)
            {
                throw new ArgumentNullException("the directiveId cannot be null");
            }
            if (processorName == null)
            {
                throw new ArgumentNullException("the processorName cannot be null");
            }
            if (parameterName == null)
            {
                throw new ArgumentNullException("the parameterName cannot be null");
            }

            //Code to provide "hard-coded" parameter values goes here.
            //This code depends on the directive processors this host will interact with.

            //If we cannot do better, return the empty string.
            return String.Empty;
        }

        /// <summary>
        /// A directive processor can call this method if a file name does not have a path.
        /// The host can attempt to provide path information by searching specific paths for the file and returning the file and path if found.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ResolvePath(string path)
        {
            if (path == null) throw new ArgumentNullException("the path cannot be null");

            //正确的完整路径
            if (File.Exists(path)) return path;

            //跟模板文件在同一目录
            string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), path);
            if (File.Exists(candidate))
            {
                return candidate;
            }

            //todo: 这里还可以执行更多的解析文件路径操作

            //若前面的解析操作无效，则返回原始路径
            return path;
        }

        /// <summary>
        /// The engine calls this method to change the extension of the generated text output file based on the optional output directive  if the user specifies it in the text template.
        /// </summary>
        /// <param name="extension">扩展名，比如".txt"</param>
        public void SetFileExtension(string extension)
        {
            _FileExtention = extension;
        }

        /// <summary>
        /// The engine calls this method to change the encoding of the generated text output file based on the optional output directive  if the user specifies it in the text template.
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="fromOutputDirective"></param>
        public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
        {
            _FileEncoding = encoding;
        }

        /// <summary>
        /// 这个是你的代码中要引入的包包，这个例子中引入了 System.dll 和 本项目的 dll，如果你不想引用，那么就得在 你的 tt 文件中引入
        /// The host can provide standard assembly references. The engine will use these references when compiling and executing the generated transformation class.
        /// </summary>
        public IList<string> StandardAssemblyReferences
        {
            get
            {
                return base.AssemblyLocationList;
            }
        }

        /// <summary>
        /// 这个是你的代码中要using 的命名空间，这个例子中引入了 System 和 本项目的，如果你不想引用，那么就得在 你的 tt 文件中写
        /// The host can provide standard imports or using statements. The engine will add these statements to the generated  transformation class.
        /// </summary>
        public IList<string> StandardImports
        {
            get
            {
                return base.NamespaceList;
            }
        }

        /// <summary>
        /// 模板文件
        /// </summary>
        public string TemplateFile
        {
            get;
            set;
        }

        #endregion
    }
}
