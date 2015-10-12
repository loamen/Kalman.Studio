using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kalman
{
    /// <summary>
    /// 基于正则表达式的验证类
    /// </summary>
    public class RegexValidate
    {
        /// <summary>
        /// 判断字符串是否与指定正则表达式匹配
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <param name="regularExp">正则表达式</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMatch(string input, string regularExp)
        {
            return Regex.IsMatch(input, regularExp);
        }

        /// <summary>
        /// 验证非负整数（正整数 + 0）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnMinusInt(string input)
        {
            return Regex.IsMatch(input, RegexConst.UnMinusInteger);
        }

        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsPlusInt(string input)
        {
            return Regex.IsMatch(input, RegexConst.PlusInteger);
        }

        /// <summary>
        /// 验证非正整数（负整数 + 0） 
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnPlusInt(string input)
        {
            return Regex.IsMatch(input, RegexConst.UnPlusInteger);
        }

        /// <summary>
        /// 验证负整数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMinusInt(string input)
        {
            return Regex.IsMatch(input, RegexConst.MinusInteger);
        }

        /// <summary>
        /// 验证整数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsInt(string input)
        {
            return Regex.IsMatch(input, RegexConst.Integer);
        }

        /// <summary>
        /// 验证非负浮点数（正浮点数 + 0）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnMinusFloat(string input)
        {
            return Regex.IsMatch(input, RegexConst.UnMinusFloat);
        }

        /// <summary>
        /// 验证正浮点数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsPlusFloat(string input)
        {
            return Regex.IsMatch(input, RegexConst.PlusFloat);
        }

        /// <summary>
        /// 验证非正浮点数（负浮点数 + 0）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnPlusFloat(string input)
        {
            return Regex.IsMatch(input, RegexConst.UnPlusFloat);
        }

        /// <summary>
        /// 验证负浮点数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMinusFloat(string input)
        {
            return Regex.IsMatch(input, RegexConst.MinusFloat);
        }

        /// <summary>
        /// 验证浮点数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsFloat(string input)
        {
            return Regex.IsMatch(input, RegexConst.Float);
        }

        /// <summary>
        /// 验证由26个英文字母组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsLetter(string input)
        {
            return Regex.IsMatch(input, RegexConst.Letter);
        }

        /// <summary>
        /// 验证由26个英文字母的大写组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUpperLetter(string input)
        {
            return Regex.IsMatch(input, RegexConst.UpperLetter);
        }

        /// <summary>
        /// 验证由26个英文字母的小写组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsLowerLetter(string input)
        {
            return Regex.IsMatch(input, RegexConst.LowerLetter);
        }

        /// <summary>
        /// 验证由数字和26个英文字母组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsNumericOrLetter(string input)
        {
            return Regex.IsMatch(input, RegexConst.NumericOrLetter);
        }

        /// <summary>
        /// 验证由数字、26个英文字母或者下划线组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsNumericOrLetterOrUnderline(string input)
        {
            return Regex.IsMatch(input, RegexConst.NumericOrLetterOrUnderline);
        }

        /// <summary>
        /// 验证email地址
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsEmail(string input)
        {
            return Regex.IsMatch(input, RegexConst.Email);
        }

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUrl(string input)
        {
            return Regex.IsMatch(input, RegexConst.Url);
        }

        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsTelephone(string input)
        {
            return Regex.IsMatch(input, RegexConst.Telephone);
        }

        /// <summary>
        /// 通过文件扩展名验证图像格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsImageFormat(string input)
        {
            return Regex.IsMatch(input, RegexConst.ImageFormat);
        }

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsIP(string input)
        {
            return Regex.IsMatch(input, RegexConst.IP);
        }

        /// <summary>
        /// 验证日期（YYYY-MM-DD）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDate(string input)
        {
            return Regex.IsMatch(input, RegexConst.Date);
        }

        /// <summary>
        /// 验证日期和时间（YYYY-MM-DD HH:MM:SS）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDateTime(string input)
        {
            return Regex.IsMatch(input, RegexConst.DateTime);
        }
    }
}
