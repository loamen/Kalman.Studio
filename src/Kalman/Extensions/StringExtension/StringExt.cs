using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Kalman.Utilities;
using Kalman.Security;

namespace Kalman.Extensions
{
    /// <summary>
    /// Stirng类型扩展方法
    /// 注：这里所有方法的实现都封装在StringUtil类中
    /// </summary>
    public static partial class StringExt
    {
        /// <summary>
        /// 将字符串首字母转成大写
        /// </summary>
        //public static string InitialToUpper(this string s)
        //{
        //    return StringUtil.InitialToUpper(s);
        //}

        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string s)
        {
            return StringUtil.ToSBC(s);
        }
        
        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        public static string ToDBC(this string s)
        {
            return StringUtil.ToDBC(s);
        }

        /// <summary>
        /// 裁剪字符串，对Substring方法的改良，参数超出范围不抛出异常
        /// 若裁剪起始位置startIndex超出字符串长度，则返回空字符串,若裁剪长度length超出范围，则返回从startIndex开始的全部字符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(this string s, int startIndex, int length)
        {
            return StringUtil.CutString(s, startIndex, length);
        }

        /// <summary>
        /// 返回指定加密哈希算法的字符串的副本
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithm">哈希算法</param>
        /// <returns></returns>
        public static string ToHash(this string s, HashAlgorithmType hashAlgorithm)
        {
            return StringUtil.ToHash(s, hashAlgorithm);
        }

        /// <summary>
        /// 判断字符串是否都是有空白字符组成，空字符串将返回false
        /// </summary>
        /// <returns>如果该字符串都是空白字符，返回<c>true</c> ，否则返回<c>false</c></returns>
        public static bool IsWhiteSpace(this string s)
        {
            return StringUtil.IsWhiteSpace(s);
        }

        /// <summary>
        /// 判断字符串是否含有空白字符
        /// </summary>
        /// <returns>如果该字符串含有空白字符，返回<c>true</c> ，否则返回<c>false</c></returns>
        public static bool HasWhiteSpace(this string s)
        {
            return StringUtil.HasWhiteSpace(s);
        }

        /// <summary>
        /// 向字符串结尾附加换行符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AppendNewLine(this string s)
        {
            return StringUtil.AppendNewLine(s);
        }

        /// <summary>
        /// 反转字符串，如：字符串“ABC”，反转后为“CBA”
        /// </summary>
        /// <returns></returns>
        public static string Reverse(this string s)
        {
            return StringUtil.Reverse(s);
        }

        /// <summary>
        /// 将字符串编码成16进制字符串，比如12345->3132333435；张三->D5C5C8FD，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToHexString(this string s, Encoding encoding)
        {
            return StringUtil.ToHexString(s, encoding);
        }

        /// <summary>
        /// 将字符串编码成16进制字符串，比如12345->3132333435；张三->D5C5C8FD，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToHexString(this string s)
        {
            return StringUtil.ToHexString(s);
        }

        /// <summary>
        /// 将16进制编码字符串还原成编码前的字符串，比如：D5C5C8FD->张三，3132333435->12345，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromHexString(this string s, Encoding encoding)
        {
            return StringUtil.FromHexString(s, encoding);
        }

        /// <summary>
        /// 将16进制编码字符串还原成编码前的字符串，比如：D5C5C8FD->张三，3132333435->12345，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FromHexString(this string s)
        {
            return StringUtil.FromHexString(s);
        }

        /// <summary>
        /// 获取字符串长度，字节长度，一个中文字符长度为2
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding">字符串编码</param>
        /// <returns></returns>
        public static int GetByteLength(this string s, Encoding encoding)
        {
            return StringUtil.GetByteLength(s, encoding);
        }

        /// <summary>
        /// 获取字符串长度，字节长度，一个中文字符长度为2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int GetByteLength(this string s)
        {
            return StringUtil.GetByteLength(s);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Base64Encode(this string s)
        {
            return StringUtil.Base64Encode(s);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Base64Encode(this string s, Encoding encoding)
        {
            return StringUtil.Base64Encode(s, encoding);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Base64Decode(this string s)
        {
            return StringUtil.Base64Decode(s);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Base64Decode(this string s, Encoding encoding)
        {
            return StringUtil.Base64Decode(s, encoding);
        }
    }
}
