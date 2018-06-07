using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Security
{
    /// <summary>
    /// 哈希算法类型
    /// </summary>
    public enum HashAlgorithmType
    {
        /// <summary>MD5 Hash</summary>
        MD5,
        /// <summary>SHA1 - A 160 bit Secure Algorithm Hash</summary>
        SHA1,
        /// <summary>SHA2 - A 256 bit Secure Algorithm Hash</summary>
        SHA256,
        /// <summary>SHA3 - A 384 bit Secure Algorithm Hash</summary>
        SHA384,
        /// <summary>SHA5 - A 512 bit Secure Algorithm Hash</summary>
        SHA512
    }
}
