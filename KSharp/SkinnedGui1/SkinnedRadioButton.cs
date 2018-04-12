using CRial.xbmcgui;
using System.IO;

namespace CRial.SkinnedGui
{
    public class SkinnedRadioButton : RadioButton
    {
        public SkinnedRadioButton(string label,Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10,
            int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0) : base(-10, -10, 1, 1,label,
            Path.Combine(Skin.DefautSkin.Images, "RadioButton", "MenuItemFO.png"),
                        Path.Combine(Skin.DefautSkin.Images, "RadioButton", "MenuItemNF.png"),
                        Path.Combine(Skin.DefautSkin.Images, "RadioButton", "radiobutton-focus.png"),
                        Path.Combine(Skin.DefautSkin.Images, "RadioButton", "radiobutton-focus.png"),
                        Path.Combine(Skin.DefautSkin.Images, "RadioButton", "radiobutton-nofocus.png"),
                        Path.Combine(Skin.DefautSkin.Images, "RadioButton", "radiobutton-nofocus.png"),
                        textColor, shadowColor,focusedColor, disabledColor, textOffsetX,textOffsetY, font, alignment, angle)
        { }
        public SkinnedRadioButton(string label, int textOffsetX = 10,int textOffsetY = 2, string font = "font13",
                Alignment alignment = Alignment.CENTER_X, int angle = 0) 
            :this(label, Colors.None, Colors.None, Colors.None, Colors.None, textOffsetX, textOffsetY, font, alignment, angle)
        {
        }

    }
}