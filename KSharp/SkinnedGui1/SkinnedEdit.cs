using CRial.xbmcgui;
using System.IO;

namespace CRial.SkinnedGui
{
    public class SkinnedEdit : Edit
    {
        public SkinnedEdit(string label, Colors textColor, Colors disabledColor, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool isPassword = false) :base(-10, -10, 1, 1, label,
            Path.Combine(Skin.DefautSkin.Images, "Edit", "button-focus.png"),
            Path.Combine(Skin.DefautSkin.Images, "Edit", "black-back2.png"),textColor,disabledColor,font:font,alignment:alignment,isPassword:isPassword)
        { }
        public SkinnedEdit(string label,string font = "font13", Alignment alignment = Alignment.CENTER_X, bool isPassword = false) 
            : this(label, Colors.None, Colors.None, font: font, alignment: alignment, isPassword: isPassword)
        { }
    }
}