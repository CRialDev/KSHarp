namespace CRial.xbmcgui
{
    public class FadeLabel : Control
    {
        #region Private Properties
        //
        private string _font = "font13";
        private Colors _textColor = Colors.Black;
        private string _label = "";
        //
        #endregion
        //
        #region Constructor
        //
        public FadeLabel(int x, int y, int width, int height, Colors textColor, string font = "font13", Alignment alignment = Alignment.CENTER_X)
        : base()
        {
            _font = font;
            _textColor = textColor;
            //
            Utils.Call(_name + " = xbmcgui.ControlFadeLabel(" + x + "," + y + "," + width + "," + height + ",font='" + _font + "', "+ Colors.ToParam("textColor", _textColor)+" _alignment =" + (int)alignment + ")");
        }
        public FadeLabel(int x, int y, int width, int height, string font = "font13", Alignment alignment = Alignment.CENTER_X) : this(x, y, width, height, Colors.None, font:font, alignment:alignment) { }

        internal FadeLabel(string name) : base(name)
        {
        }

        //
        #endregion
        //
        #region Properties Read Only
        //
        public string Font
        {
            get { return _font; }
        }
        public Colors TextColor
        {
            get { return _textColor; }
        }
        //
        #endregion
        //
        #region Properties
        //
        public string Label
        {
            set { ClearLabel(); _label = value; Utils.Call(_name + ".addLabel('" + _label + "')"); }
            get { return _label; }
        }
        //
        #endregion
        //
        #region Functions
        //
        public void ClearLabel()
        {
            _label = "";
            Utils.Call(_name + ".reset()");
        }
        //
        #endregion
    }
}