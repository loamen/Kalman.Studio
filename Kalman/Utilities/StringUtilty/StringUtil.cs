using Kalman.Data.SchemaObject;
using Kalman.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman.Utilities
{
    public static partial class StringUtil
    {
        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(string s)
        {
            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        public static string ToDBC(string s)
        {
            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        #region Cut String

        /// <summary>
        /// 裁剪字符串，对Substring方法的改良，参数超出范围不抛出异常
        /// 若裁剪起始位置startIndex超出字符串长度，则返回空字符串,若裁剪长度length超出范围，则返回从startIndex开始的全部字符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(string s, int startIndex, int length)
        {
            //若裁剪起始位置超出字符串长度，则返回空字符串
            if (startIndex >= s.Length) return string.Empty;

            //字符串裁剪后的剩余长度
            int remainLength = s.Length - startIndex;

            if (length > remainLength)
                return s.Substring(startIndex);
            else
                return s.Substring(startIndex, length);
        }

        /// <summary>
        /// 截断右边多余字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="length">保留字符串长度</param>
        /// <returns>截断后的字符串</returns>
        public static string CutRight(string s, int length)
        {
            return CutRight(s, length, "...");
        }

        /// <summary>
        /// 截断右边多余字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="length">保留字符串长度</param>
        /// <param name="suffix">截断部分替代字符</param>
        /// <returns>截断后的字符串</returns>
        public static string CutRight(string s, int length, string suffix)
        {
            if (length < GetBitLength(s))
            {
                return (GetLeftByteString(s, length) + suffix);
            }
            return s;
        }

        /// <summary>
        /// 获取字符串字节长度,中文字符算2个字符
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>字符串长度</returns>
        [Obsolete("请改用GetByteLength方法")]
        public static int GetBitLength(string s)
        {
            return Encoding.Default.GetBytes(s).Length;
        }

        /// <summary>
        /// 获取字符串长度，字节长度，一个中文字符长度为2
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding">字符串编码</param>
        /// <returns></returns>
        public static int GetByteLength(string s, Encoding encoding)
        {
            return encoding.GetByteCount(s);
        }

        /// <summary>
        /// 获取字符串长度，字节长度，一个中文字符长度为2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int GetByteLength(string s)
        {
            return GetByteLength(s, Encoding.Default);
        }

        /// <summary>
        /// 截断右边多余字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="byteLength">字节长度</param>
        /// <returns>处理后的字符串</returns>
        public static string GetLeftByteString(string s, int byteLength)
        {
            char[] arr;
            if (s.Length <= (byteLength / 2))
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            int num = 0;
            if (s.Length < byteLength)
            {
                arr = s.ToCharArray();
            }
            else
            {
                arr = s.ToCharArray(0, byteLength);
            }
            foreach (char ch in arr)
            {
                if (ch > '\x007f')
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
                sb.Append(ch);
                if (num >= byteLength)
                {
                    break;
                }
            }
            return sb.ToString();
        }

        #endregion

        /// <summary>
        /// 返回指定加密哈希算法的字符串的副本
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithm">哈希算法</param>
        /// <returns></returns>
        public static string ToHash(string s, HashAlgorithmType hashAlgorithm)
        {
            return HashCryto.GetHash2String(s, hashAlgorithm);
        }

        /// <summary>
        /// 判断字符串是否都是有空白字符组成，空字符串将返回false
        /// </summary>
        /// <returns>如果该字符串都是空白字符，返回<c>true</c> ，否则返回<c>false</c></returns>
        public static bool IsWhiteSpace(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            if (s.Length == 0)
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 判断字符串是否含有空白字符
        /// </summary>
        /// <returns>如果该字符串含有空白字符，返回<c>true</c> ，否则返回<c>false</c></returns>
        public static bool HasWhiteSpace(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 向字符串结尾附加换行符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AppendNewLine(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            return s + Environment.NewLine;
        }

        /// <summary>
        /// 反转字符串，如：字符串“ABC”，反转后为“CBA”
        /// </summary>
        /// <returns></returns>
        public static string Reverse(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            char[] characters = s.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        /// <summary>
        /// 将字符串编码成16进制字符串，比如12345->3132333435；张三->D5C5C8FD，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToHexString(string s, Encoding encoding)
        {
            byte[] data = encoding.GetBytes(s);
            string result = ByteUtil.ToHex(data);
            return result;
        }

        /// <summary>
        /// 将字符串编码成16进制字符串，比如12345->3132333435；张三->D5C5C8FD，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToHexString(string s)
        {
            return ToHexString(s, Encoding.Default);
        }

        /// <summary>
        /// 将16进制编码字符串还原成编码前的字符串，比如：D5C5C8FD->张三，3132333435->12345，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string FromHexString(string s, Encoding encoding)
        {
            List<byte> list = new List<byte>();

            for (int i = 0; i < s.Length; i = i + 2)
            {
                string c = s.Substring(i, 2);
                byte b = Convert.ToByte(c, 16);
                list.Add(b);
            }

            string result = encoding.GetString(list.ToArray());
            return result;
        }

        /// <summary>
        /// 将16进制编码字符串还原成编码前的字符串，比如：D5C5C8FD->张三，3132333435->12345，使用当前系统默认编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FromHexString(string s)
        {
            return FromHexString(s, Encoding.Default);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Base64Encode(string s)
        {
            return Base64Encode(s, Encoding.Default);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Base64Encode(string s, Encoding encoding)
        {
            byte[] data = encoding.GetBytes(s);
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Base64Decode(string s)
        {
            return Base64Decode(s, Encoding.Default);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Base64Decode(string s, Encoding encoding)
        {
            byte[] data = Convert.FromBase64String(s);
            return encoding.GetString(data);
        }
    }
}
