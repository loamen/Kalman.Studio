using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Security
{
    /// <summary>
    /// 对称加密算法类型枚举
    /// </summary>
    public enum SymmetricAlgorithmType
    {
        /// <summary>
        /// 数据加密标准，速度较快，适用于加密大量数据的场合，密钥长度固定为64
        /// </summary>
        DES,
        /// <summary>
        /// RC2加密算法，密钥长度40，用变长密钥对大量数据进行加密，比 DES 快
        /// </summary>
        RC2_40,
        /// <summary>
        /// RC2加密算法，密钥长度64，用变长密钥对大量数据进行加密，比 DES 快
        /// </summary>
        RC2_64,
        /// <summary>
        /// RC2加密算法，密钥长度96，用变长密钥对大量数据进行加密，比 DES 快
        /// </summary>
        RC2_96,
        /// <summary>
        /// RC2加密算法，密钥长度128，用变长密钥对大量数据进行加密，比 DES 快
        /// </summary>
        RC2_128,
        /// <summary>
        /// Rijndael加密算法，密钥长度128
        /// AES（Advanced Encryption Standard）：高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法； 
        /// </summary>
        Rijndael_128,
        /// <summary>
        /// Rijndael加密算法，密钥长度192
        /// AES（Advanced Encryption Standard）：高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法； 
        /// </summary>
        Rijndael_192,
        /// <summary>
        /// Rijndael加密算法，密钥长度256
        /// AES（Advanced Encryption Standard）：高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法； 
        /// </summary>
        Rijndael_256,
        /// <summary>
        /// 3DES加密算法，密钥长度128
        /// 3DES（Triple DES）：是基于DES，对一块数据用三个不同的密钥进行三次加密，强度更高； 
        /// </summary>
        TripleDES_128,
        /// <summary>
        /// 3DES加密算法，密钥长度192
        /// 3DES（Triple DES）：是基于DES，对一块数据用三个不同的密钥进行三次加密，强度更高； 
        /// </summary>
        TripleDES_192
    }
}
