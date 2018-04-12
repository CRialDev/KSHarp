namespace CRial.xbmcgui
{
    public class Label : Control
    {
        #region Private Properties
        //
        private string _font = "font13";
        private Colors _textColor;
        private Colors _disabledColor;
        private bool _hasPath = false;
        private int _angle = 0;
        private int _alignment = 2;
        //
        #endregion
        //
        #region Constructor
        //
        public Label(int x, int y, int width, int height, string label, Colors textColor, Colors disabledColor, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool hasPath = false, int angle = 0) : base()
        {
            _angle = angle;
            _font = font;
            _textColor = textColor;
            _disabledColor = disabledColor;
            _hasPath = hasPath;
            _alignment = (int)alignment;
            string colors = Colors.ToParam("textColor", _textColor) + Colors.ToParam("disabledColor", _disabledColor);
            //
            Utils.Call(_name + " = xbmcgui.ControlLabel(" + x + "," + y + "," + width + "," + height + ",'" + label + "',font='" + _font + "',"+colors+" alignment=" + (int)alignment + ", hasPath=" + _hasPath.ToString() + ", angle=" + _angle + ")");
        }
        public Label(int x, int y, int width, int height, string label, string font = "font13", Alignment alignment = Alignment.CENTER_X, bool hasPath = false, int angle = 0)
        : this(x, y, width, height, label, Colors.None, Colors.None) { }

        internal Label(string name) : base(name)
        {
        }

        //
        #endregion
        //
        #region Properties Read Only
        //
        public bool HasPath
        {
            get { return _hasPath; }
        }
        public int Angle
        {
            get { return _angle; }
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
        public string label
        {
            set { Utils.Call(_name + ".setLabel('" + value + "')"); }
            get { return Utils.Call<string>(_name + ".getLabel()"); }
        }
        //
        #endregion
    }

}
