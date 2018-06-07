using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman
{
    /// <summary>
    /// 常用正则表达式
    /// </summary>
    public struct RegexConst
    {
        /// <summary>
        /// 非负整数
        /// </summary>
        public const string UnMinusInteger = "\\d+$";

        /// <summary>
        /// 正整数
        /// </summary>
        public const string PlusInteger = "^[0-9]*[1-9][0-9]*$";

        /// <summary>
        /// 非正整数（负整数 + 0） 
        /// </summary>
        public const string UnPlusInteger = "^((-\\d+)|(0+))$";

        /// <summary>
        /// 负整数
        /// </summary>
        public const string MinusInteger = "^-[0-9]*[1-9][0-9]*$";

        /// <summary>
        /// 整数
        /// </summary>
        public const string Integer = "^-?\\d+$";

        /// <summary>
        /// 非负浮点数（正浮点数 + 0）
        /// </summary>
        public const string UnMinusFloat = "^\\d+(\\.\\d+)?$";

        /// <summary>
        /// 正浮点数
        /// </summary>
        public const string PlusFloat = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";

        /// <summary>
        /// 非正浮点数（负浮点数 + 0）
        /// </summary>
        public const string UnPlusFloat = "^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$";

        /// <summary>
        /// 负浮点数
        /// </summary>
        public const string MinusFloat = "^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";

        /// <summary>
        /// 浮点数
        /// </summary>
        public const string Float = "^(-?\\d+)(\\.\\d+)?$";

        /// <summary>
        /// 由26个英文字母组成的字符串
        /// </summary>
        public const string Letter = "^[A-Za-z]+$";

        /// <summary>
        /// 由26个英文字母的大写组成的字符串
        /// </summary>
        public const string UpperLetter = "^[A-Z]+$";

        /// <summary>
        /// 由26个英文字母的小写组成的字符串
        /// </summary>
        public const string LowerLetter = "^[a-z]+$";

        /// <summary>
        /// 由数字和26个英文字母组成的字符串
        /// </summary>
        public const string NumericOrLetter = "^[A-Za-z0-9]+$";

        /// <summary>
        /// 由数字、26个英文字母或者下划线组成的字符串
        /// </summary>
        public const string NumericOrLetterOrUnderline = "^\\w+$";

        /// <summary>
        /// email地址
        /// </summary>
        //public const string Email = "^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$";
        public const string Email = @"^([a-zA-Z0-9_'+*$%\^&!\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9:]{2,4})+$";

        /// <summary>
        /// URL
        /// </summary>
        public const string Url = "^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";

        /// <summary>
        /// 电话号码
        /// </summary>
        public const string Telephone = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";

        /// <summary>
        /// 图像文件扩展名
        /// </summary>
        public const string ImageFormat = @"\.(?i:gif|jpg|bmp)$";

        /// <summary>
        /// IP地址
        /// </summary>
        public const string IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>
        /// 日期（YYYY-MM-DD）
        /// </summary>
        public const string Date = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";

        /// <summary>
        /// 日期和时间（YYYY-MM-DD HH:MM:SS）
        /// </summary>
        public const string DateTime = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";

        //手机号码：^(13[0-9]|15[0-9]|18[0-9])\d{8}$
    

    }
}
