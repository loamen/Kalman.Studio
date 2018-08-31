using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public class Config
    {
        public const string HOME_PAGE = "http://www.loamen.com";
        /// <summary>
        /// 临时BAT执行文件
        /// </summary>
        public static string TEMP_BAT_FILENAME = NormalConfig.SettingPath + @"\temp.bat"; //临时BAT执行文件

        public static Main MainForm
        {
            get
            {
                var fm = (Main)Application.OpenForms["Main"];
                return fm;
            }
        }

        public static DatabaseExplorer DatabaseExplorer
        {
            get
            {
                var fm = (DatabaseExplorer)Application.OpenForms["DatabaseExplorer"];
                return fm;
            }
        }

        #region 封装对输出窗体的操作
        /// <summary>
        /// 向输出窗体追加一行文本
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newLine"></param>
        public static void Console(string text,bool newLine = true)
        {
            MainForm.AppendOutputLine(text, newLine);
        }

        /// <summary>
        /// 输出异常
        /// </summary>
        /// <param name="ex"></param>
        public static void ConsoleException(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.Source);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine(ex.HelpLink);

            MainForm.AppendOutputLine(sb.ToString(), true);
        }
        #endregion

    }
}
