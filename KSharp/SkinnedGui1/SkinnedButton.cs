using CRial.xbmcgui;
using System.IO;

namespace CRial.SkinnedGui
{
    public class SkinnedButton : Button
    {
        public SkinnedButton(string label, Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0) :
            base(-10, -10, 1, 1, label,
            Path.Combine(Skin.DefautSkin.Images, "Button", "KeyboardKey.png"),
            Path.Combine(Skin.DefautSkin.Images, "Button", "KeyboardKeyNF.png"), textColor, shadowColor, focusedColor, disabledColor,
            textOffsetX: textOffsetX, textOffsetY: textOffsetY, font: font, alignment: alignment, angle: angle)
        { }
        public SkinnedButton(string label, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0) :
            this(label, Colors.None, Colors.None, Colors.None, Colors.None,
            textOffsetX: textOffsetX, textOffsetY: textOffsetY, font: font, alignment: alignment, angle: angle)
        { }
    }
}