using CRial.xbmcgui;

namespace CRial.SkinnedGui
{
    public class SkinnedTextBox : TextBox
    {
        public SkinnedTextBox(Colors textColor,string font= "font13"):base(-10, -10, 1, 1, textColor,font:font)
        { }
        public SkinnedTextBox(string font = "font13") : this(Colors.None, font: font)
        { }

    }
}