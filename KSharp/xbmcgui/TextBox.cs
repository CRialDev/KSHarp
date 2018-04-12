namespace CRial.xbmcgui
{
    public class TextBox : Control
    {
        #region Private Properties
        //
        private string _font = "font13";
        private Colors _textColor = Colors.Black;
        //
        #endregion
        //
        #region Constructor
        //
        public TextBox(int x, int y, int width, int height, Colors textColor, string font = "font13")
        : base()
        {
            _font = font;
            _textColor = textColor;
            Utils.Call(_name + " = xbmcgui.ControlTextBox(" + x + "," + y + "," + width + "," + height + ","+ Colors.ToParam("textColor", _textColor)+" font ='" + font + "')");
        }
        public TextBox(int x, int y, int width, int height, string font = "font13")
        : this(x, y, width, height, Colors.None) { }

        internal TextBox(string name) : base(name)
        {
        }

        //
        #endregion
        //
        #region Functions
        //
        public void autoScroll(int delay, int time, int repeat)
        {
            Utils.Call(_name + ".autoScroll(" + delay + "," + time + "," + repeat + ")");
        }
        public void scroll(int position)
        {
            Utils.Call(_name + ".scroll(" + position + ")");
        }
        public void reset()
        {
            Utils.Call(_name + ".reset()");
        }
        //
        #endregion
        //
        #region Properties
        //
        public string Text
        {
            set { Utils.Call(_name + ".setText('" + value + "')"); }
            get { return Utils.Call<string>(_name + ".getText()"); }
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
    }
}