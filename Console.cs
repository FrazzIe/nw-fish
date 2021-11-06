using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace nw_fish
{
    [ToolboxItem(true)]
    public class ConsoleBox : TextBox
    {
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;

        [DefaultValue(true)]
        public bool SelectionHighlightEnabled { get; set; }

        public ConsoleBox()
        {
            SelectionHighlightEnabled = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS && !SelectionHighlightEnabled)
                m.Msg = WM_KILLFOCUS;

            base.WndProc(ref m);
        }
    }
}
