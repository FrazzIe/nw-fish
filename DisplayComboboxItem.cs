using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nw_fish
{
    public class DisplayComboboxItem
    {
        public string Text { get; }
        public object Value { get; }

        public DisplayComboboxItem(Screen screen, int idx)
        {            
            Text = $"Display {idx + 1} - {screen.Bounds.Width}x{screen.Bounds.Height}" + (screen.Primary ? " (Primary)" : "");
            Value = screen;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
