using CRial.xbmcgui;

namespace CRial.SkinnedGui
{
    public class SkinnedLabel : Label
    {
        public SkinnedLabel(string label,Colors textColor, Colors disabledColor, string font = "font13", Alignment alignment = Alignment.LEFT, bool hasPath = false, int angle = 0) 
            : base(-10, -10, 1, 1, label,textColor,disabledColor, alignment: alignment, font: font, hasPath: hasPath, angle: angle)
        {
        }
        public SkinnedLabel(string label, string font="font13",Alignment alignment= Alignment.LEFT, bool hasPath= false,int angle= 0)
            : this(label,Colors.None,Colors.None, alignment:alignment,font:font,hasPath:hasPath,angle:angle)
        {
        }
    }
}