using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public class RadioButton : Control
    {
        #region Private Properties
        //
        private string _font;
        private Colors _textColor;
        private Colors _disabledColor;
        private Colors _shadowColor;
        private Colors _focusedColor;
        private int _textOffsetX;
        private int _textOffsetY;
        private int _angle;
        private string _focusTexture;
        private string _noFocusTexture;
        private string _focusOnTexture;
        private string _noFocusOnTexture;
        private string _focusOffTexture;
        private string _noFocusOffTexture;
        private string _label;
        //
        #endregion
        //
        #region Constructor
        //
        public RadioButton(int x, int y, int width, int height, string label, Colors focusColor, Colors noFocusColor,
            Colors focusOnColor, Colors noFocusOnColor, Colors focusOffColor, Colors noFocusOffColor,
            Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10,
            int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : this(x, y, width, height, label, focusColor.Texture, noFocusColor.Texture,
            focusOnColor.Texture, noFocusOnColor.Texture, focusOffColor.Texture, noFocusOffColor.Texture,
            textColor, shadowColor, focusedColor, disabledColor, textOffsetX,
            textOffsetY, font, alignment, angle) { }
        public RadioButton(int x, int y, int width, int height, string label,string focusTexture, string noFocusTexture,
            string focusOnTexture, string noFocusOnTexture,string focusOffTexture,string noFocusOffTexture,
            Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10,
            int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : base()
        {
            _label = label;
            _focusOnTexture = focusOnTexture;
            _noFocusOnTexture = noFocusOnTexture;
            _focusOffTexture = focusOffTexture;
            _noFocusOffTexture = noFocusOffTexture;
            _focusTexture = focusTexture;
            _noFocusTexture = noFocusTexture;
            _textOffsetX = textOffsetX;
            _textOffsetY = textOffsetY;
            _angle = angle;
            _disabledColor = disabledColor;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _shadowColor = shadowColor;
            _focusedColor = focusedColor;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor) + Colors.ToParam("focusedColor", _focusedColor) + Colors.ToParam("shadowColor", _shadowColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlRadioButton(" + x + "," + y + "," + width + "," + height + ",'" + label + "',focusOnTexture = '" + _focusOnTexture + "',noFocusOnTexture = '" + _noFocusOnTexture + "',focusOffTexture = '" + _focusOffTexture + "',noFocusOffTexture = '" + _noFocusOffTexture + "',focusTexture = '" + _focusTexture + "', noFocusTexture = '" + _noFocusTexture + "',textOffsetX = " + _textOffsetX + ", textOffsetY = " + _textOffsetY + ",font='" + _font + "', "+ colors + "  _alignment=" + (int)alignment + ", angle=" + _angle + ")");
        }
        public RadioButton(int x, int y, int width, int height, string label, Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : base()
        {
            _label = label;
            _focusOnTexture = null;
            _noFocusOnTexture = null;
            _focusOffTexture = null;
            _noFocusOffTexture = null;
            _focusTexture = null;
            _noFocusTexture = null;
            _textOffsetX = textOffsetX;
            _textOffsetY = textOffsetY;
            _angle = angle;
            _disabledColor = disabledColor;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _shadowColor = shadowColor;
            _focusedColor = focusedColor;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor) + Colors.ToParam("focusedColor", _focusedColor) + Colors.ToParam("shadowColor", _shadowColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlRadioButton(" + x + "," + y + "," + width + "," + height + ",'" + label + "',textOffsetX = " + _textOffsetX + ", textOffsetY = " + _textOffsetY + ",font='" + _font + "', " + colors + "_alignment =" + (int)alignment + ", angle=" + _angle + ")");
        }
        public RadioButton(int x, int y, int width, int height, string label, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : this(x, y, width, height, label, Colors.None, Colors.None, Colors.None, Colors.None) { }
        internal RadioButton(string name) : base(name)
        {
        }
        #endregion
        //
        #region Properties Read Only
        //
        public string NoFocusOffTexture
        {
            get
            {
                return _noFocusOffTexture;
            }
        }
        public string FocusOffTexture
        {
            get
            {
                return _focusOffTexture;
            }
        }
        public string NoFocusOnTexture
        {
            get
            {
                return _noFocusOnTexture;
            }
        }
        public string FocusOnTexture
        {
            get
            {
                return _focusOnTexture;
            }
        }
        public string FocusTexture
        {
            get
            {
                return _focusTexture;
            }
        }
        public string NoFocusTexture
        {
            get
            {
                return _noFocusTexture;
            }
        }
        public int TextOffsetX
        {
            get { return _textOffsetX; }
        }
        public int TextOffsetY
        {
            get { return _textOffsetY; }
        }
        public int Angle
        {
            get { return _angle; }
        }
        //
        #endregion
        //
        public bool Selected
        {
            get
            {
                return Utils.Call<bool>(_name + ".isSelected()");
            }
            set
            {
                Utils.Call(_name + ".setSelected(" + value.ToString() + ")");
            }

        }
        public string Label
        {
            get { return _label; }
            set { _label = value; Utils.Call(_name + ".setLabel('" + value + "')"); }
        }
        public void SetRadioDimension(int x,int y,int width,int height)
        {
            Utils.Call(_name + ".setRadioDimension(x="+x+", y="+y+", width="+width+", height="+height+")");
        }
    }
}
