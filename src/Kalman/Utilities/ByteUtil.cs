using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Kalman.Security;

namespace Kalman.Utilities
{
    public static class ByteUtil
    {
        /// <summary>
        /// 转十六进制
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ToHex(byte b)
        {
            return b.ToString("X2");
        }

        /// <summary>
        /// 转十六进制
        /// </summary>
        public static string ToHex(IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        /// <summary>
        /// 将 8 位无符号整数数组转换为它的等效 System.String 表示形式（使用 Base 64 数字编码）
        /// </summary>
        public static string ToBase64String(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的八个字节转换来的 32 位有符号整数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int ToInt(byte[] data, int startIndex)
        {
            return BitConverter.ToInt32(data, startIndex);
        }

        /// <summary>
        /// 返回由字节数组中指定位置的八个字节转换来的 64 位有符号整数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static long ToInt64(byte[] data, int startIndex)
        {
            return BitConverter.ToInt64(data, startIndex);
        }

        /// <summary>
        /// 转换为指定编码字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Decode(byte[] data, Encoding encoding)
        {
            return encoding.GetString(data);
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public static void Save(byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }

        /// <summary>
        /// 保存到内存流
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(byte[] data)
        {
            return new MemoryStream(data);
        }

        /// <summary>
        /// 使用指定哈希算法计算哈希值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hashEnum"></param>
        /// <returns></returns>
        public static byte[] ComputeHash(byte[] data, HashAlgorithmType hashAlgorithmType)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create(hashAlgorithmType.ToString());
            return algorithm.ComputeHash(data);
        }

        /// <summary>
        /// 使用默认Hash算法SHA1计算哈希值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ComputeHash(byte[] data)
        {
            return ComputeHash(data, HashAlgorithmType.SHA1);
        }
    }
}
