using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Kalman.Utilities;

// Kalman Create by 2010-03-09
namespace Kalman.Security
{
    /// <summary>
    /// 对称加密算法
    /// </summary>
    public class SymmetricCryto
    {
        // 随机字符串，长度为32，由于密钥最大长度为256，若用户输入的密钥长度不够，用该字符串来补足
        const string _RandomKey = "#a,7.~_*j8'/m[%}?@d2!9ge)^;<u:=+"; //32*8=256
        const string _RandomIV = "#a,7.~_*j8'/m[%}?@d2!9ge)^;<u:=+"; //32*8=256
        string _Key = "Kalman.Security";
        string _IV = "Kalman.Security";
        int factorKey = 8;//密钥长度因子
        int multiKey = 1;//密钥长度倍数
        int factorIV = 8;//初始化向量长度因子
        int multiIV = 8;//初始化向量长度倍数

        // 对称加密算法提供者，默认使用DESCryptoServiceProvider
        SymmetricAlgorithm symmetricAlgorithmProvider = new DESCryptoServiceProvider();

        #region 构造函数

        public SymmetricCryto(SymmetricAlgorithmType symmetricAlgorithmType)
        {
            symmetricAlgorithmProvider = CreateSymmetricAlgorithmProvider(symmetricAlgorithmType);
        }

        public SymmetricCryto(string key, SymmetricAlgorithmType symmetricAlgorithmType)
        {
            if (key != null) _Key = key;
            symmetricAlgorithmProvider = CreateSymmetricAlgorithmProvider(symmetricAlgorithmType);
        }

        public SymmetricCryto(string key, string iv, SymmetricAlgorithmType symmetricAlgorithmType)
        {
            if (key != null) _Key = key;
            if (iv != null) _IV = iv;
            symmetricAlgorithmProvider = CreateSymmetricAlgorithmProvider(symmetricAlgorithmType);
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 创建一个对称加密算法提供者实例
        /// </summary>
        /// <param name="symmetricAlgorithmType"></param>
        /// <returns></returns>
        SymmetricAlgorithm CreateSymmetricAlgorithmProvider(SymmetricAlgorithmType symmetricAlgorithmType)
        {
            SymmetricAlgorithm symmetricAlgorithm = null;
            switch (symmetricAlgorithmType)
            {
                case SymmetricAlgorithmType.DES:
                    //<key:64,block:64,feedback:8>,key[64,64<skip:0>],block[64,64<skip:0>] ; IV[8byte],KEY[8byte]
                    symmetricAlgorithm = new DESCryptoServiceProvider();
                    multiKey = 8;
                    multiIV = 8;
                    break;
                case SymmetricAlgorithmType.RC2_40:
                    //<key:128,block:64,feedback:8>,key[40,128<skip:8>],block[64,64<skip:0>] ; IV[8byte],KEY[16byte]
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    multiKey = 5;
                    multiIV = 8;
                    break;
                case SymmetricAlgorithmType.RC2_64:
                    //<key:128,block:64,feedback:8>,key[40,128<skip:8>],block[64,64<skip:0>] ; IV[8byte],KEY[16byte]
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    multiKey = 8;
                    multiIV = 8;
                    break;
                case SymmetricAlgorithmType.RC2_96:
                    //<key:128,block:64,feedback:8>,key[40,128<skip:8>],block[64,64<skip:0>] ; IV[8byte],KEY[16byte]
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    multiKey = 12;
                    multiIV = 8;
                    break;
                case SymmetricAlgorithmType.RC2_128:
                    //<key:128,block:64,feedback:8>,key[40,128<skip:8>],block[64,64<skip:0>] ; IV[8byte],KEY[16byte]
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    multiKey = 16;
                    multiIV = 8;
                    break;
                case SymmetricAlgorithmType.Rijndael_128:
                    //<key:256,block:128,feedback:128>,key[128,256<skip:64>],block[128,256<skip:64>] ; IV[16byte],KEY[32byte]
                    symmetricAlgorithm = new RijndaelManaged();
                    multiKey = 16;
                    multiIV = 16;
                    break;
                case SymmetricAlgorithmType.Rijndael_192:
                    //<key:256,block:128,feedback:128>,key[128,256<skip:64>],block[128,256<skip:64>] ; IV[16byte],KEY[32byte]
                    symmetricAlgorithm = new RijndaelManaged();
                    multiKey = 24;
                    multiIV = 16;
                    break;
                case SymmetricAlgorithmType.Rijndael_256:
                    //<key:256,block:128,feedback:128>,key[128,256<skip:64>],block[128,256<skip:64>] ; IV[16byte],KEY[32byte]
                    symmetricAlgorithm = new RijndaelManaged();
                    multiKey = 32;
                    multiIV = 16;
                    break;
                case SymmetricAlgorithmType.TripleDES_128:
                    //<key:192,block:64,feedback:8>,key[128,192<skip:64>],block[64,64<skip:0>] ; IV[8byte],KEY[24byte]
                    symmetricAlgorithm = new TripleDESCryptoServiceProvider();
                    multiKey = 16;
                    multiIV = 8;
                    break;
                case SymmetricAlgorithmType.TripleDES_192:
                    //<key:192,block:64,feedback:8>,key[128,192<skip:64>],block[64,64<skip:0>] ; IV[8byte],KEY[24byte]
                    symmetricAlgorithm = new TripleDESCryptoServiceProvider();
                    multiKey = 24;
                    multiIV = 8;
                    break;
                default:
                    break;
            }

            symmetricAlgorithm.KeySize = factorKey * multiKey;
            symmetricAlgorithm.BlockSize = factorIV * multiIV;

            return symmetricAlgorithm;
        }

        /// <summary>
        /// 生成合法的密钥
        /// </summary>
        byte[] GetLegalKey()
        {
            string tmp = this._Key;

            if (tmp.Length < multiKey)
            {
                tmp += _RandomKey.Substring(0, multiKey - tmp.Length);
            }
            else if (tmp.Length > multiKey)
            {
                tmp = tmp.Substring(0, multiKey);
            }

            return ASCIIEncoding.ASCII.GetBytes(tmp);
        }

        /// <summary>
        /// 生成合法的初始化向量
        /// </summary>
        byte[] GetLegalIV()
        {
            string tmp = this._IV;

            if (tmp.Length < multiIV)
            {
                tmp += _RandomIV.Substring(0, multiIV - tmp.Length);
            }
            else if (tmp.Length > multiIV)
            {
                tmp = tmp.Substring(0, multiIV);
            }

            return ASCIIEncoding.ASCII.GetBytes(tmp);
        }

        #endregion

        #region 加密方法
        /// <summary>
        /// 加密为字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string EncryptString(string s)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            byte[] inputData = Encoding.UTF8.GetBytes(s);
            byte[] outputData = null;

            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                symmetricAlgorithmProvider.Key = GetLegalKey();
                symmetricAlgorithmProvider.IV = GetLegalIV();

                ICryptoTransform cryptoTransform = symmetricAlgorithmProvider.CreateEncryptor();

                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                {
                    cs.Write(inputData, 0, inputData.Length);
                    cs.FlushFinalBlock();

                    outputData = ms.ToArray();
                }
            }

            return Convert.ToBase64String(outputData, 0, outputData.Length);
        }

        /// <summary>
        /// 加密为数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] EncryptData(string s)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            byte[] inputData = Encoding.UTF8.GetBytes(s);
            byte[] outputData = null;

            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                symmetricAlgorithmProvider.Key = GetLegalKey();
                symmetricAlgorithmProvider.IV = GetLegalIV();

                ICryptoTransform cryptoTransform = symmetricAlgorithmProvider.CreateEncryptor();

                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                {
                    cs.Write(inputData, 0, inputData.Length);
                    cs.FlushFinalBlock();

                    outputData = ms.ToArray();
                }
            }

            return outputData;
        }

        /// <summary>
        /// 加密为数据
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public byte[] EncryptData(byte[] inputData)
        {
            CheckUtil.ArgumentNotNull(inputData, "inputData");

            byte[] outputData = null;

            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                symmetricAlgorithmProvider.Key = GetLegalKey();
                symmetricAlgorithmProvider.IV = GetLegalIV();

                ICryptoTransform cryptoTransform = symmetricAlgorithmProvider.CreateEncryptor();

                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                {
                    cs.Write(inputData, 0, inputData.Length);
                    cs.FlushFinalBlock();

                    outputData = ms.ToArray();
                }
            }

            return outputData;
        }

        /// <summary>
        /// 加密为字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string EncryptString(byte[] inputData)
        {
            CheckUtil.ArgumentNotNull(inputData, "inputData");

            byte[] outputData = null;

            using (MemoryStream ms = new System.IO.MemoryStream())
            {
                symmetricAlgorithmProvider.Key = GetLegalKey();
                symmetricAlgorithmProvider.IV = GetLegalIV();

                ICryptoTransform cryptoTransform = symmetricAlgorithmProvider.CreateEncryptor();

                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                {
                    cs.Write(inputData, 0, inputData.Length);
                    cs.FlushFinalBlock();

                    outputData = ms.ToArray();
                }
            }

            return Convert.ToBase64String(outputData, 0, outputData.Length);
        }

        #endregion

        #region 解密方法

        /// <summary>
        /// 解密为字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecryptString(string s)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            byte[] inputData = Convert.FromBase64String(s);
            string result = string.Empty;

            using (MemoryStream ms = new System.IO.MemoryStream(inputData))
            {
                symmetricAlgorithmProvider.Key = GetLegalKey();
                symmetricAlgorithmProvider.IV = GetLegalIV();

                ICryptoTransform encrypto = symmetricAlgorithmProvider.CreateDecryptor();

                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                result = sr.ReadLine();

                //CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                //byte[] outputData = new byte[inputData.Length];
                //cs.Read(outputData, 0, outputData.Length);

                //result = Encoding.UTF8.GetString(outputData).TrimEnd(new char[] { '\0' });

                cs.Clear();
                cs.Close();
            }

            return result;
        }

        /// <summary>
        /// 解密为数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] DecryptData(string s)
        {
            CheckUtil.ArgumentNotNullOrEmpty(s, "s");

            byte[] inputData = Convert.FromBase64String(s);
            byte[] outputData = null;

            using (MemoryStream ms = new System.IO.MemoryStream(inputData))
            {
                symmetricAlgorithmProvider.Key = GetLegalKey();
                symmetricAlgorithmProvider.IV = GetLegalIV();

                ICryptoTransform encrypto = symmetricAlgorithmProvider.CreateDecryptor();

                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                outputData = new byte[inputData.Length];
                cs.Read(outputData, 0, outputData.Length);

                cs.Clear();
                cs.Close();
            }

            return outputData;
        }

        #endregion
    }
}
