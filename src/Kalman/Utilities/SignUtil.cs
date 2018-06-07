using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Security.Cryptography;
using Kalman.Security;
using Kalman.Extensions;

namespace Kalman.Utilities
{
    /// <summary>
    /// 签名工具类，用于计算接口调用时计算接口签名
    /// </summary>
    public class SignUtil
    {
        HashAlgorithmType _HashAlgorithmType;
        Encoding _Encoding;

        /// <summary>
        /// 构造函数，初始化签名算法为MD5，编码为UTF-8
        /// </summary>
        public SignUtil()
        {
            _HashAlgorithmType = HashAlgorithmType.MD5;
            _Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// 构造函数，初始化签名算法为MD5
        /// </summary>
        /// <param name="encoding"></param>
        public SignUtil(Encoding encoding)
        {
            _HashAlgorithmType = HashAlgorithmType.MD5;
            _Encoding = encoding;
        }

        /// <summary>
        /// 构造函数，初始化编码为UTF-8
        /// </summary>
        public SignUtil(HashAlgorithmType hashAlgorithmType)
        {
            _HashAlgorithmType = hashAlgorithmType;
            _Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// 构造函数，需要指定签名算法及编码
        /// </summary>
        public SignUtil(HashAlgorithmType hashAlgorithmType, Encoding encoding)
        {
            _HashAlgorithmType = hashAlgorithmType;
            _Encoding = encoding;
        }

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="nvc">该集合保存签名相关参数的值</param>
        /// <param name="secretKey">签名密钥</param>
        /// <returns></returns>
        public string Sign(NameValueCollection nvc, string secretKey)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> temp in nvc)
            {
                sb.Append(temp.Value);
            }

            sb.Append(secretKey);

            string s = HashCryto.GetHash2String(sb.ToString(), _HashAlgorithmType, _Encoding);
            return s;
        }

        /// <summary>
        /// 生成带签名的url
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public string SignUrl(string baseUrl, NameValueCollection urlParams, string secretKey)
        {
            var allKeys = urlParams.AllKeys;

            return SignUrl(baseUrl, urlParams, allKeys, secretKey);
        }

        /// <summary>
        /// 生成带签名的url，参数顺序按字母顺序
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="urlParams"></param>
        /// <returns></returns>
        public string SignUrlInAlphabeticalOrder(string baseUrl, NameValueCollection urlParams, string secretKey)
        {
            var allKeys = urlParams.AllKeys.OrderBy(p => p);
            return SignUrl(baseUrl, urlParams, allKeys, secretKey);
        }

        private string SignUrl(string baseUrl, NameValueCollection urlParams, IEnumerable<string> allKeys, string key)
        {
            StringBuilder urlBuilder = new StringBuilder(baseUrl + "?");
            //创建待加密字符串
            StringBuilder paramString = new StringBuilder();

            foreach (var k in allKeys)
            {
                paramString.Append(urlParams[k]);
                urlBuilder.Append(string.Format("{0}={1}&", k, urlParams[k]));
            }

            paramString.Append(key);

            //加密
            string signedString = HashCryto.GetHash2String(paramString.ToString(), _HashAlgorithmType, _Encoding);

            urlBuilder.Append(string.Format("{0}={1}", "sign", signedString));

            return urlBuilder.ToString();
        }

        ///// <summary>
        ///// MD5加密
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //public static string EncryptByMD5(string str)
        //{
        //    MD5 md5 = MD5.Create();
        //    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        //    StringBuilder sBuilder = new StringBuilder();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        sBuilder.Append(s[i].ToString("X2"));
        //    }
        //    return sBuilder.ToString();
        //}
    }
}
