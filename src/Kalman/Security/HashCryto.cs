using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using Kalman.Utilities;

// Kalman Create by 2010-03-08
namespace Kalman.Security
{
    /// <summary>
    /// 哈希加密算法
    /// </summary>
    public static class HashCryto
    {
        #region 计算文件流的哈希值

        /// <summary>
        /// 计算文件流的哈希值
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static byte[] GetHash(FileStream fileStream, HashAlgorithmType hashAlgorithmType)
        {
            CheckUtil.ArgumentNotNull(fileStream, "fileStream");

            HashAlgorithm hashAlgorithm = CreateHashAlgorithmProvider(hashAlgorithmType);
            byte[] result = hashAlgorithm.ComputeHash(fileStream);
            hashAlgorithm.Clear();
            fileStream.Close();

            return result;
        }

        /// <summary>
        /// 计算文件流的哈希值并将其转换为字符串
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2String(FileStream fileStream, HashAlgorithmType hashAlgorithmType)
        {
            CheckUtil.ArgumentNotNull(fileStream, "fileStream");

            string result = string.Empty;
            byte[] bytes = GetHash(fileStream, hashAlgorithmType);

            foreach (byte b in bytes)
            {
                result += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
            }

            return result;
        }

        /// <summary>
        /// 计算文件流的哈希值并将其转换为使用Base64编码的字符串
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2Base64(FileStream fileStream, HashAlgorithmType hashAlgorithmType)
        {
            CheckUtil.ArgumentNotNull(fileStream, "fileStream");

            byte[] bytes = GetHash(fileStream, hashAlgorithmType);
            string result = Convert.ToBase64String(bytes);

            return result;
        }

        #endregion

        #region 计算字节数组的哈希值

        /// <summary>
        /// 计算字节数组的哈希值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static byte[] GetHash(byte[] data, HashAlgorithmType hashAlgorithmType)
        {
            CheckUtil.ArgumentNotNull(data, "data");

            HashAlgorithm hashAlgorithm = CreateHashAlgorithmProvider(hashAlgorithmType);
            byte[] result = hashAlgorithm.ComputeHash(data);
            hashAlgorithm.Clear();

            return result;
        }

        /// <summary>
        /// 计算字节数组的哈希值并将其转换为字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2String(byte[] data, HashAlgorithmType hashAlgorithmType)
        {
            CheckUtil.ArgumentNotNull(data, "data");

            string result = string.Empty;
            byte[] bytes = GetHash(data, hashAlgorithmType);

            foreach (byte b in bytes)
            {
                result += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
            }

            return result;
        }

        /// <summary>
        /// 计算字节数组的哈希值并将其转换为使用Base64编码的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2Base64(byte[] data, HashAlgorithmType hashAlgorithmType)
        {
            CheckUtil.ArgumentNotNull(data, "data");

            byte[] bytes = GetHash(data, hashAlgorithmType);
            string result = Convert.ToBase64String(bytes);

            return result;
        }

        #endregion

        #region 计算字符串的哈希值

        /// <summary>
        /// 计算字符串的哈希值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static byte[] GetHash(string s, HashAlgorithmType hashAlgorithmType)
        {
            return GetHash(s, hashAlgorithmType, Encoding.Default);
        }

        /// <summary>
        /// 计算字符串的哈希值
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <param name="encoding">指定字符串的编码</param>
        /// <returns></returns>
        public static byte[] GetHash(string s, HashAlgorithmType hashAlgorithmType, Encoding encoding)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            byte[] data = encoding.GetBytes(s);
            return GetHash(data, hashAlgorithmType);
        }

        /// <summary>
        /// 计算字符串的哈希值并将其转换为字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2String(string s, HashAlgorithmType hashAlgorithmType)
        {
            return GetHash2String(s, hashAlgorithmType, Encoding.Default);
        }

        /// <summary>
        /// 计算字符串的哈希值并将其转换为字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <param name="encoding">指定字符串的编码</param>
        /// <returns></returns>
        public static string GetHash2String(string s, HashAlgorithmType hashAlgorithmType, Encoding encoding)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            string result = string.Empty;
            byte[] bytes = GetHash(s, hashAlgorithmType, encoding);

            foreach (byte b in bytes)
            {
                result += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
            }

            return result;
        }

        /// <summary>
        /// 计算字符串的哈希值并将其转换为使用Base64编码的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2Base64(string s, HashAlgorithmType hashAlgorithmType)
        {
            return GetHash2Base64(s, hashAlgorithmType, Encoding.Default);
        }

        /// <summary>
        /// 计算字符串的哈希值并将其转换为使用Base64编码的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static string GetHash2Base64(string s, HashAlgorithmType hashAlgorithmType, Encoding encoding)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            byte[] data = GetHash(s, hashAlgorithmType, encoding);
            string result = Convert.ToBase64String(data);

            return result;
        }

        #endregion

        /// <summary>
        /// 创建一个哈希算法提供者实例
        /// </summary>
        /// <param name="hashAlgorithmType"></param>
        /// <returns></returns>
        public static HashAlgorithm CreateHashAlgorithmProvider(HashAlgorithmType hashAlgorithmType)
        {
            HashAlgorithm hashAlgorithm = null;

            switch (hashAlgorithmType)
            {
                case HashAlgorithmType.MD5:
                    hashAlgorithm = new MD5CryptoServiceProvider();
                    break;
                case HashAlgorithmType.SHA1:
                    hashAlgorithm = new SHA1Managed();
                    break;
                case HashAlgorithmType.SHA256:
                    hashAlgorithm = new SHA256Managed();
                    break;
                case HashAlgorithmType.SHA384:
                    hashAlgorithm = new SHA384Managed();
                    break;
                case HashAlgorithmType.SHA512:
                    hashAlgorithm = new SHA512Managed();
                    break;
                default:
                    hashAlgorithm = new MD5CryptoServiceProvider();
                    break;
            }

            return hashAlgorithm;
        }
    }
}
