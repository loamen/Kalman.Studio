using Kalman.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kalman.Studio
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region DAL init
            DbConnDAL.Init();
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
