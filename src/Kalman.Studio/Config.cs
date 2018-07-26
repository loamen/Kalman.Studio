using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public class Config
    {
        public static Main MainForm
        {
            get
            {
                var fm = (Main)Application.OpenForms["Main"];
                return fm;
            }
        }
    }
}
