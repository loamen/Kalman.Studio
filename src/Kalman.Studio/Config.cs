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
    }
}
