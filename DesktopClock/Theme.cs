using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock
{
    public class Theme
    {
        public string Name { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }

        public Theme(string name, Color bgColor, Color textColor)
        {
            Name = name;
            BackgroundColor = bgColor;
            TextColor = textColor;
        }
    }
}
