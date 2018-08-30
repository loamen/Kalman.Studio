using System;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public class MsgBox
    {
        /// <summary>
        ///     显示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Show(string msg, string title = "错误")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
        }

        /// <summary>
        ///     显示错误信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ShowErrorMessage(string msg, string title = "错误")
        {
            Config.Console(msg);
            return MessageBox.Show(msg, "title", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     显示异常数据
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static DialogResult ShowExceptionMessage(Exception ex, string title = "异常")
        {
            Config.Console(ex.ToString());
            return MessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     显示问题信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult ShowQuestionMessage(string msg,string title = "提示")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
        }

        /// <summary>
        /// 显示异常窗口
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DialogResult ShowExceptionDialog(Exception ex,string data = null)
        {
            Config.Console(ex.ToString());
            ErrorInfo ei = new ErrorInfo(ex, data);
            return ei.ShowDialog();
        }
    }
}