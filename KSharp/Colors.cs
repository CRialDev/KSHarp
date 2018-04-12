using CRial.xbmcaddon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial
{
    public struct Colors
    {
        private string _hex;
        private string _name;
        //
        public Colors(string name, string hex)
        {
            this._name = name;
            this._hex = hex;
        }
        public string Name
        {
            get { return _name; }
        }
        internal string Texture
        {
            get { return Path.Combine(new Addon().getAddonInfo("path"), "KSharp", "Colors", _name + ".png"); }
        }
        public string Hex
        {
            get { return _hex; }
        }
        //
        internal static string ToParam(string paramname, Colors _Color)
        {
            if (_Color.Name == "None")
                return "";
            else
                return paramname + " = '" + _Color + "',";
        }
        public static implicit operator string(Colors value)
        {
                return value._hex;
        }
        //
        public static Colors None = new Colors("None", "");
        public static Colors ActiveBorder = new Colors("ActiveBorder", "0xFFB4B4B4");
        public static Colors ActiveCaption = new Colors("ActiveCaption", "0xFF99B4D1");
        public static Colors ActiveCaptionText = new Colors("ActiveCaptionText", "0xFF000000");
        public static Colors AppWorkspace = new Colors("AppWorkspace", "0xFFABABAB");
        public static Colors Control = new Colors("Control", "0xFFF0F0F0");
        public static Colors ControlDark = new Colors("ControlDark", "0xFFA0A0A0");
        public static Colors ControlDarkDark = new Colors("ControlDarkDark", "0xFF696969");
        public static Colors ControlLight = new Colors("ControlLight", "0xFFE3E3E3");
        public static Colors ControlLightLight = new Colors("ControlLightLight", "0xFFFFFFFF");
        public static Colors ControlText = new Colors("ControlText", "0xFF000000");
        public static Colors Desktop = new Colors("Desktop", "0xFF000000");
        public static Colors GrayText = new Colors("GrayText", "0xFF6D6D6D");
        public static Colors Highlight = new Colors("Highlight", "0xFF0078D7");
        public static Colors HighlightText = new Colors("HighlightText", "0xFFFFFFFF");
        public static Colors HotTrack = new Colors("HotTrack", "0xFF0066CC");
        public static Colors InactiveBorder = new Colors("InactiveBorder", "0xFFF4F7FC");
        public static Colors InactiveCaption = new Colors("InactiveCaption", "0xFFBFCDDB");
        public static Colors InactiveCaptionText = new Colors("InactiveCaptionText", "0xFF000000");
        public static Colors Info = new Colors("Info", "0xFFFFFFE1");
        public static Colors InfoText = new Colors("InfoText", "0xFF000000");
        public static Colors Menu = new Colors("Menu", "0xFFF0F0F0");
        public static Colors MenuText = new Colors("MenuText", "0xFF000000");
        public static Colors ScrollBar = new Colors("ScrollBar", "0xFFC8C8C8");
        public static Colors Window = new Colors("Window", "0xFFFFFFFF");
        public static Colors WindowFrame = new Colors("WindowFrame", "0xFF646464");
        public static Colors WindowText = new Colors("WindowText", "0xFF000000");
        public static Colors Transparent = new Colors("Transparent", "0xFFFFFFFF");
        public static Colors AliceBlue = new Colors("AliceBlue", "0xFFF0F8FF");
        public static Colors AntiqueWhite = new Colors("AntiqueWhite", "0xFFFAEBD7");
        public static Colors Aqua = new Colors("Aqua", "0xFF00FFFF");
        public static Colors Aquamarine = new Colors("Aquamarine", "0xFF7FFFD4");
        public static Colors Azure = new Colors("Azure", "0xFFF0FFFF");
        public static Colors Beige = new Colors("Beige", "0xFFF5F5DC");
        public static Colors Bisque = new Colors("Bisque", "0xFFFFE4C4");
        public static Colors Black = new Colors("Black", "0xFF000000");
        public static Colors BlanchedAlmond = new Colors("BlanchedAlmond", "0xFFFFEBCD");
        public static Colors Blue = new Colors("Blue", "0xFF0000FF");
        public static Colors BlueViolet = new Colors("BlueViolet", "0xFF8A2BE2");
        public static Colors Brown = new Colors("Brown", "0xFFA52A2A");
        public static Colors BurlyWood = new Colors("BurlyWood", "0xFFDEB887");
        public static Colors CadetBlue = new Colors("CadetBlue", "0xFF5F9EA0");
        public static Colors Chartreuse = new Colors("Chartreuse", "0xFF7FFF00");
        public static Colors Chocolate = new Colors("Chocolate", "0xFFD2691E");
        public static Colors Coral = new Colors("Coral", "0xFFFF7F50");
        public static Colors CornflowerBlue = new Colors("CornflowerBlue", "0xFF6495ED");
        public static Colors Cornsilk = new Colors("Cornsilk", "0xFFFFF8DC");
        public static Colors Crimson = new Colors("Crimson", "0xFFDC143C");
        public static Colors Cyan = new Colors("Cyan", "0xFF00FFFF");
        public static Colors DarkBlue = new Colors("DarkBlue", "0xFF00008B");
        public static Colors DarkCyan = new Colors("DarkCyan", "0xFF008B8B");
        public static Colors DarkGoldenrod = new Colors("DarkGoldenrod", "0xFFB8860B");
        public static Colors DarkGray = new Colors("DarkGray", "0xFFA9A9A9");
        public static Colors DarkGreen = new Colors("DarkGreen", "0xFF006400");
        public static Colors DarkKhaki = new Colors("DarkKhaki", "0xFFBDB76B");
        public static Colors DarkMagenta = new Colors("DarkMagenta", "0xFF8B008B");
        public static Colors DarkOliveGreen = new Colors("DarkOliveGreen", "0xFF556B2F");
        public static Colors DarkOrange = new Colors("DarkOrange", "0xFFFF8C00");
        public static Colors DarkOrchid = new Colors("DarkOrchid", "0xFF9932CC");
        public static Colors DarkRed = new Colors("DarkRed", "0xFF8B0000");
        public static Colors DarkSalmon = new Colors("DarkSalmon", "0xFFE9967A");
        public static Colors DarkSeaGreen = new Colors("DarkSeaGreen", "0xFF8FBC8B");
        public static Colors DarkSlateBlue = new Colors("DarkSlateBlue", "0xFF483D8B");
        public static Colors DarkSlateGray = new Colors("DarkSlateGray", "0xFF2F4F4F");
        public static Colors DarkTurquoise = new Colors("DarkTurquoise", "0xFF00CED1");
        public static Colors DarkViolet = new Colors("DarkViolet", "0xFF9400D3");
        public static Colors DeepPink = new Colors("DeepPink", "0xFFFF1493");
        public static Colors DeepSkyBlue = new Colors("DeepSkyBlue", "0xFF00BFFF");
        public static Colors DimGray = new Colors("DimGray", "0xFF696969");
        public static Colors DodgerBlue = new Colors("DodgerBlue", "0xFF1E90FF");
        public static Colors Firebrick = new Colors("Firebrick", "0xFFB22222");
        public static Colors FloralWhite = new Colors("FloralWhite", "0xFFFFFAF0");
        public static Colors ForestGreen = new Colors("ForestGreen", "0xFF228B22");
        public static Colors Fuchsia = new Colors("Fuchsia", "0xFFFF00FF");
        public static Colors Gainsboro = new Colors("Gainsboro", "0xFFDCDCDC");
        public static Colors GhostWhite = new Colors("GhostWhite", "0xFFF8F8FF");
        public static Colors Gold = new Colors("Gold", "0xFFFFD700");
        public static Colors Goldenrod = new Colors("Goldenrod", "0xFFDAA520");
        public static Colors Gray = new Colors("Gray", "0xFF808080");
        public static Colors Green = new Colors("Green", "0xFF008000");
        public static Colors GreenYellow = new Colors("GreenYellow", "0xFFADFF2F");
        public static Colors Honeydew = new Colors("Honeydew", "0xFFF0FFF0");
        public static Colors HotPink = new Colors("HotPink", "0xFFFF69B4");
        public static Colors IndianRed = new Colors("IndianRed", "0xFFCD5C5C");
        public static Colors Indigo = new Colors("Indigo", "0xFF4B0082");
        public static Colors Ivory = new Colors("Ivory", "0xFFFFFFF0");
        public static Colors Khaki = new Colors("Khaki", "0xFFF0E68C");
        public static Colors Lavender = new Colors("Lavender", "0xFFE6E6FA");
        public static Colors LavenderBlush = new Colors("LavenderBlush", "0xFFFFF0F5");
        public static Colors LawnGreen = new Colors("LawnGreen", "0xFF7CFC00");
        public static Colors LemonChiffon = new Colors("LemonChiffon", "0xFFFFFACD");
        public static Colors LightBlue = new Colors("LightBlue", "0xFFADD8E6");
        public static Colors LightCoral = new Colors("LightCoral", "0xFFF08080");
        public static Colors LightCyan = new Colors("LightCyan", "0xFFE0FFFF");
        public static Colors LightGoldenrodYellow = new Colors("LightGoldenrodYellow", "0xFFFAFAD2");
        public static Colors LightGray = new Colors("LightGray", "0xFFD3D3D3");
        public static Colors LightGreen = new Colors("LightGreen", "0xFF90EE90");
        public static Colors LightPink = new Colors("LightPink", "0xFFFFB6C1");
        public static Colors LightSalmon = new Colors("LightSalmon", "0xFFFFA07A");
        public static Colors LightSeaGreen = new Colors("LightSeaGreen", "0xFF20B2AA");
        public static Colors LightSkyBlue = new Colors("LightSkyBlue", "0xFF87CEFA");
        public static Colors LightSlateGray = new Colors("LightSlateGray", "0xFF778899");
        public static Colors LightSteelBlue = new Colors("LightSteelBlue", "0xFFB0C4DE");
        public static Colors LightYellow = new Colors("LightYellow", "0xFFFFFFE0");
        public static Colors Lime = new Colors("Lime", "0xFF00FF00");
        public static Colors LimeGreen = new Colors("LimeGreen", "0xFF32CD32");
        public static Colors Linen = new Colors("Linen", "0xFFFAF0E6");
        public static Colors Magenta = new Colors("Magenta", "0xFFFF00FF");
        public static Colors Maroon = new Colors("Maroon", "0xFF800000");
        public static Colors MediumAquamarine = new Colors("MediumAquamarine", "0xFF66CDAA");
        public static Colors MediumBlue = new Colors("MediumBlue", "0xFF0000CD");
        public static Colors MediumOrchid = new Colors("MediumOrchid", "0xFFBA55D3");
        public static Colors MediumPurple = new Colors("MediumPurple", "0xFF9370DB");
        public static Colors MediumSeaGreen = new Colors("MediumSeaGreen", "0xFF3CB371");
        public static Colors MediumSlateBlue = new Colors("MediumSlateBlue", "0xFF7B68EE");
        public static Colors MediumSpringGreen = new Colors("MediumSpringGreen", "0xFF00FA9A");
        public static Colors MediumTurquoise = new Colors("MediumTurquoise", "0xFF48D1CC");
        public static Colors MediumVioletRed = new Colors("MediumVioletRed", "0xFFC71585");
        public static Colors MidnightBlue = new Colors("MidnightBlue", "0xFF191970");
        public static Colors MintCream = new Colors("MintCream", "0xFFF5FFFA");
        public static Colors MistyRose = new Colors("MistyRose", "0xFFFFE4E1");
        public static Colors Moccasin = new Colors("Moccasin", "0xFFFFE4B5");
        public static Colors NavajoWhite = new Colors("NavajoWhite", "0xFFFFDEAD");
        public static Colors Navy = new Colors("Navy", "0xFF000080");
        public static Colors OldLace = new Colors("OldLace", "0xFFFDF5E6");
        public static Colors Olive = new Colors("Olive", "0xFF808000");
        public static Colors OliveDrab = new Colors("OliveDrab", "0xFF6B8E23");
        public static Colors Orange = new Colors("Orange", "0xFFFFA500");
        public static Colors OrangeRed = new Colors("OrangeRed", "0xFFFF4500");
        public static Colors Orchid = new Colors("Orchid", "0xFFDA70D6");
        public static Colors PaleGoldenrod = new Colors("PaleGoldenrod", "0xFFEEE8AA");
        public static Colors PaleGreen = new Colors("PaleGreen", "0xFF98FB98");
        public static Colors PaleTurquoise = new Colors("PaleTurquoise", "0xFFAFEEEE");
        public static Colors PaleVioletRed = new Colors("PaleVioletRed", "0xFFDB7093");
        public static Colors PapayaWhip = new Colors("PapayaWhip", "0xFFFFEFD5");
        public static Colors PeachPuff = new Colors("PeachPuff", "0xFFFFDAB9");
        public static Colors Peru = new Colors("Peru", "0xFFCD853F");
        public static Colors Pink = new Colors("Pink", "0xFFFFC0CB");
        public static Colors Plum = new Colors("Plum", "0xFFDDA0DD");
        public static Colors PowderBlue = new Colors("PowderBlue", "0xFFB0E0E6");
        public static Colors Purple = new Colors("Purple", "0xFF800080");
        public static Colors Red = new Colors("Red", "0xFFFF0000");
        public static Colors RosyBrown = new Colors("RosyBrown", "0xFFBC8F8F");
        public static Colors RoyalBlue = new Colors("RoyalBlue", "0xFF4169E1");
        public static Colors SaddleBrown = new Colors("SaddleBrown", "0xFF8B4513");
        public static Colors Salmon = new Colors("Salmon", "0xFFFA8072");
        public static Colors SandyBrown = new Colors("SandyBrown", "0xFFF4A460");
        public static Colors SeaGreen = new Colors("SeaGreen", "0xFF2E8B57");
        public static Colors SeaShell = new Colors("SeaShell", "0xFFFFF5EE");
        public static Colors Sienna = new Colors("Sienna", "0xFFA0522D");
        public static Colors Silver = new Colors("Silver", "0xFFC0C0C0");
        public static Colors SkyBlue = new Colors("SkyBlue", "0xFF87CEEB");
        public static Colors SlateBlue = new Colors("SlateBlue", "0xFF6A5ACD");
        public static Colors SlateGray = new Colors("SlateGray", "0xFF708090");
        public static Colors Snow = new Colors("Snow", "0xFFFFFAFA");
        public static Colors SpringGreen = new Colors("SpringGreen", "0xFF00FF7F");
        public static Colors SteelBlue = new Colors("SteelBlue", "0xFF4682B4");
        public static Colors Tan = new Colors("Tan", "0xFFD2B48C");
        public static Colors Teal = new Colors("Teal", "0xFF008080");
        public static Colors Thistle = new Colors("Thistle", "0xFFD8BFD8");
        public static Colors Tomato = new Colors("Tomato", "0xFFFF6347");
        public static Colors Turquoise = new Colors("Turquoise", "0xFF40E0D0");
        public static Colors Violet = new Colors("Violet", "0xFFEE82EE");
        public static Colors Wheat = new Colors("Wheat", "0xFFF5DEB3");
        public static Colors White = new Colors("White", "0xFFFFFFFF");
        public static Colors WhiteSmoke = new Colors("WhiteSmoke", "0xFFF5F5F5");
        public static Colors Yellow = new Colors("Yellow", "0xFFFFFF00");
        public static Colors YellowGreen = new Colors("YellowGreen", "0xFF9ACD32");
        public static Colors ButtonFace = new Colors("ButtonFace", "0xFFF0F0F0");
        public static Colors ButtonHighlight = new Colors("ButtonHighlight", "0xFFFFFFFF");
        public static Colors ButtonShadow = new Colors("ButtonShadow", "0xFFA0A0A0");
        public static Colors GradientActiveCaption = new Colors("GradientActiveCaption", "0xFFB9D1EA");
        public static Colors GradientInactiveCaption = new Colors("GradientInactiveCaption", "0xFFD7E4F2");
        public static Colors MenuBar = new Colors("MenuBar", "0xFFF0F0F0");
        public static Colors MenuHighlight = new Colors("MenuHighlight", "0xFF3399FF");
    }
}
