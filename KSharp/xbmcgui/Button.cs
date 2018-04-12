namespace CRial.xbmcgui
{
    public class Button : Control
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

        //
        #endregion
        //
        #region Constructor
        //focusTexture, noFocusTexture,
        public Button(int x, int y, int width, int height, string label, Colors focusColor, Colors noFocusColor, Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : this(x, y, width, height, label, focusColor.Texture, noFocusColor.Texture, textColor, shadowColor, focusedColor, disabledColor, textOffsetX, textOffsetY, font, alignment, angle) {}
        public Button(int x, int y, int width, int height, string label,string focusTexture,string noFocusTexture, Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : base()
        {
            _focusTexture = focusTexture;
            _noFocusTexture = noFocusTexture;
            _textOffsetX = textOffsetX;
            _textOffsetY = textOffsetY;
            _angle = angle;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _shadowColor = shadowColor;
            _focusedColor = focusedColor;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor) + Colors.ToParam("focusedColor", _focusedColor) + Colors.ToParam("shadowColor", _shadowColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlButton(" + x + "," + y + "," + width + "," + height + ",'" + label + "',"+colors+" focusTexture = '"+_focusTexture+"', noFocusTexture = '"+_noFocusTexture+"',textOffsetX = " + _textOffsetX + ", textOffsetY = " + _textOffsetY + ",font='" + _font + "', alignment=" + (int)alignment + ", angle=" + _angle + ")");
        }
        public Button(int x, int y, int width, int height, string label, Colors textColor, Colors shadowColor, Colors focusedColor, Colors disabledColor, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : base()
        {
            _focusTexture = null;
            _noFocusTexture = null;
            _textOffsetX = textOffsetX;
            _textOffsetY = textOffsetY;
            _angle = angle;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _shadowColor = shadowColor;
            _focusedColor = focusedColor;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor) + Colors.ToParam("focusedColor", _focusedColor) + Colors.ToParam("shadowColor", _shadowColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlButton(" + x + "," + y + "," + width + "," + height + ",'" + label + "',"+colors+ " textOffsetX = " + _textOffsetX + ", textOffsetY = " + _textOffsetY + ",font='" + _font + "', alignment=" + (int)alignment + ", angle=" + _angle + ")");
        }
        public Button(int x, int y, int width, int height, string label, int textOffsetX = 10, int textOffsetY = 2, string font = "font13", Alignment alignment = Alignment.CENTER_X, int angle = 0)
        : this(x, y, width, height, label, Colors.None, Colors.None, Colors.None, Colors.None) { }
        internal Button(string name) : base(name)
        {
        }
        //
        #endregion
        //
        #region Properties Read Only
        //
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
        #region Properties
        //
        public Colors DisabledColor
        {
            set { _disabledColor = value; Utils.Call(_name + ".setDisabledColor('" + _disabledColor + "')"); }
            get { return _disabledColor; }
        }
        public string Label
        {
            get { return Utils.Call<string>(_name + ".getLabel()"); }
            set { Utils.Call(_name + ".setLabel(label='" + value + "')"); }
        }
        public string Label2
        {
            get { return Utils.Call<string>(_name + ".getLabel2()"); }
            set
            {
                string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("focusedColor", _focusedColor) + Colors.ToParam("shadowColor", _shadowColor);
                Utils.Call(_name + ".setLabel(label=" + _name + ".getLabel(), label2='" + value + "',"+colors+" font='" + _font + "')"); }
        }
        //
        #endregion
    }
}