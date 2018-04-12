namespace CRial.xbmcgui
{
    public class Edit : Control
    {
        #region Private Properties
        //
        private string _font = "font13";
        private Colors _textColor;
        private Colors _disabledColor;
        private bool _isPassword = false;
        private int _alignment = 2;
        private string _focusTexture;
        private string _noFocusTexture;

        //
        #endregion
        //
        #region Constructor
        //
        public Edit(int x, int y, int width, int height, string label, Colors focusColor, Colors noFocusColor, Colors textColor, Colors disabledColor, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool isPassword = false) 
            : this(x, y, width, height, label, focusColor.Texture, noFocusColor.Texture, textColor, disabledColor, font, alignment,isPassword)
        { }
            public Edit(int x, int y, int width, int height, string label, string focusTexture, string noFocusTexture, Colors textColor, Colors disabledColor, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool isPassword = false)
            : base()
        {
            _focusTexture = focusTexture;
            _noFocusTexture = noFocusTexture;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _alignment = (int)alignment;
            _isPassword = isPassword;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlEdit(" + x + "," + y + "," + width + "," + height + ",'" + label + "',focusTexture = '" + _focusTexture + "', noFocusTexture = '" + _noFocusTexture + "', font='" + font + "',"+colors+" _alignment=" + (int)alignment + ",isPassword=" + isPassword.ToString() + ")");
        }
        public Edit(int x, int y, int width, int height, string label, Colors textColor, Colors disabledColor, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool isPassword = false) : base()
        {
            _focusTexture = null;
            _noFocusTexture = null;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _alignment = (int)alignment;
            _isPassword = isPassword;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlEdit(" + x + "," + y + "," + width + "," + height + ",'" + label + "', font='" + font + "', "+colors+" _alignment=" + (int)alignment + ",isPassword=" + isPassword.ToString() + ")");
        }
        public Edit(int x, int y, int width, int height, string label, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool isPassword = false)
        : this(x, y, width, height, label, Colors.None, Colors.None) { }

        internal Edit(string name) : base(name)
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
        public bool IsPassword
        {
            get { return _isPassword; }
        }
        public string Font
        {
            get { return _font; }
        }
        public Colors TextColor
        {
            get { return _textColor; }
        }
        public Colors DisabledColor
        {
            get { return _disabledColor; }
        }
        //
        #endregion
        //
        #region Properties
        //
        public string Label
        {
            set { Utils.Call(_name + ".setLabel('" + value + "')"); }
            get { return Utils.Call<string>(_name + ".getLabel()"); }
        }
        public string Text
        {
            set { Utils.Call(_name + ".setText('" + value + "')"); }
            get { return Utils.Call<string>(_name + ".getText()"); }
        }
        public void setLabelColors(Colors textcolor)
        {
            Utils.Call(_name + ".setLabel(" + _name + ".getLabel(), textColor='" + textcolor + "')");
        }
        //
        #endregion
    }

}