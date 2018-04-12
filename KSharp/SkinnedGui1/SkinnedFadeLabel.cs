using CRial.xbmcgui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.SkinnedGui
{
    public class SkinnedFadeLabel : FadeLabel
    {
        public SkinnedFadeLabel(string font = "font13", Alignment alignment = Alignment.CENTER_X) : 
            base(-10, -10, 1, 1, font: font, alignment: alignment)
        { }
        public SkinnedFadeLabel(Colors textColor, string font = "font13", Alignment alignment = Alignment.CENTER_X) : 
            base(-10, -10, 1, 1, textColor, font: font, alignment: alignment)
        { }
    }
}
