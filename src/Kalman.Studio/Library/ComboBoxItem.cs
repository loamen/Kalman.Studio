using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalman.Studio
{
    [Serializable]
    public class ComboBoxItem
    {
        public ComboBoxItem() { }
        public ComboBoxItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }
        public string Text { get; set; }
        public object Value { get; set; }
    }
}
