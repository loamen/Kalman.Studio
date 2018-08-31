using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Studio
{
    /// <summary>
    /// 可高亮显示的代码类型
    /// </summary>
    public struct CodeType
    {
        /// <summary>
        /// Mode file="ASPX.xshd" name="ASP/XHTML" extensions=".asp;.aspx;.asax;.asmx" 
        /// </summary>
        public const string ASPX = "ASP/XHTML";
        /// <summary>
        /// Mode file="BAT-Mode.xshd" name="BAT" extensions=".bat"  
        /// </summary>
        public const string BAT = "BAT";
        /// <summary>
        /// Mode file="Boo.xshd" name="Boo" extensions=".boo" 
        /// </summary>
        public const string BOO = "Boo";
        /// <summary>
        /// Mode file="Coco-Mode.xshd" name="Coco" extensions=".atg" 
        /// </summary>
        public const string COCO = "Coco";
        /// <summary>
        /// Mode file="CPP-Mode.xshd" name="C++.NET" extensions=".c;.h;.cc;.C;.cpp;.hpp" 
        /// </summary>
        public const string CPP = "C++.NET";
        /// <summary>
        /// Mode file="CSharp-Mode.xshd" name="C#" extensions=".cs" 
        /// </summary>
        public const string CSHARP = "C#";
        /// <summary>
        /// Mode file="HTML-Mode.xshd" name="HTML" extensions=".htm;.html" 
        /// </summary>
        public const string HTML = "HTML";
        /// <summary>
        /// Mode file="Java-Mode.xshd" name="Java" extensions=".java" 
        /// </summary>
        public const string JAVA = "Java";
        /// <summary>
        /// Mode file="JavaScript-Mode.xshd" name="JavaScript" extensions=".js" 
        /// </summary>
        public const string JS = "JavaScript";
        /// <summary>
        /// Mode file="Patch-Mode.xshd" name="Patch" extensions=".patch;.diff" 
        /// </summary>
        public const string PATCH = "Patch";
        /// <summary>
        /// Mode file="PHP-Mode.xshd" name="PHP" extensions=".php" 
        /// </summary>
        public const string PHP = "PHP";
        /// <summary>
        /// Mode file="Tex-Mode.xshd" name="TeX" extensions=".tex" 
        /// </summary>
        public const string TEX = "TeX";
        /// <summary>
        /// Mode file="VBNET-Mode.xshd" name="VBNET" extensions=".vb" 
        /// </summary>
        public const string VB = "VBNET";
        /// <summary>
        /// Mode file="XML-Mode.xshd" name="XML" extensions=".xml;.xsl;.xslt;.xsd;.manifest;.config;.addin;.xshd;.wxs;.wxi;.wxl;.proj;.csproj;.vbproj;.ilproj;.booproj;.build;.xfrm;.targets;.xaml;.xpt;.xft;.map;.wsdl;.disco" 
        /// </summary>
        public const string XML = "XML";
        /// <summary>
        /// Mode file="TSQL-Mode.xshd" name="TSQL" extensions=".sql" 
        /// </summary>
        public const string TSQL = "TSQL";
    }

    public static class CodeTypeHelper
    {
        /// <summary>
        /// 根据文件扩展名返回对应的CodeType
        /// </summary>
        /// <param name="extention"></param>
        /// <returns></returns>
        public static string GetCodeType(string extention)
        {
            extention = extention.ToLower();
            switch (extention)
            {
                case ".asp":
                case ".aspx":
                case ".asax":
                case ".asmx":
                case ".jsp":
                    return CodeType.ASPX;
                case ".bat":
                    return CodeType.BAT;
                case ".boo":
                    return CodeType.BOO;
                case ".atg":
                    return CodeType.COCO;
                case ".c":
                case ".h":
                case ".cpp":
                case ".cc":
                case ".hpp":
                case ".go":
                    return CodeType.CPP;
                case ".cs":
                    return CodeType.CSHARP;
                case ".htm":
                case ".html":
                    return CodeType.HTML;
                case ".java":
                case ".py":
                    return CodeType.JAVA;
                case ".js":
                    return CodeType.JS;
                case ".patch":
                case ".diff":
                    return CodeType.PATCH;
                case ".php":
                    return CodeType.PHP;
                case ".tex":
                    return CodeType.TEX;
                case ".sql":
                    return CodeType.TSQL;
                case ".vb":
                    return CodeType.VB;
                case ".xml":
                case ".xsl":
                case ".xslt":
                case ".xsd":
                case ".manifest":
                case ".config":
                case ".addin":
                case ".xshd":
                case ".wxs":
                case ".wxi":
                case ".wxl":
                case ".proj":
                case ".csproj":
                case ".vbproj":
                case ".ilproj":
                case ".booproj":
                case ".build":
                case ".xfrm":
                case ".targets":
                case ".xaml":
                case ".xpt":
                case ".xft":
                case ".map":
                case ".wsdl":
                case ".disco":
                    return CodeType.XML;
                default:
                    return CodeType.CSHARP;
            }
        }

        /// <summary>
        /// 根据代码类型返回该类型代码文件的默认扩展名，如代码类型为CodeType.ASPX，那么默认扩展名为".aspx"
        /// </summary>
        /// <param name="codeType"></param>
        /// <returns></returns>
        public static string GetExtention(string codeType)
        {
            switch (codeType)
            {
                case CodeType.ASPX:
                    return ".aspx";
                case CodeType.BAT:
                    return ".bat";
                case CodeType.BOO:
                    return ".boo";
                case CodeType.CPP:
                    return ".cpp";
                case CodeType.CSHARP:
                    return ".cs";
                case CodeType.HTML:
                    return ".html";
                case CodeType.JAVA:
                    return ".java";
                case CodeType.JS:
                    return ".js";
                case CodeType.PHP:
                    return ".php";
                case CodeType.TSQL:
                    return ".sql";
                case CodeType.VB:
                    return ".vb";
                case CodeType.XML:
                    return ".xml";
                default:
                    return ".txt";
            }
        }
    }
}
