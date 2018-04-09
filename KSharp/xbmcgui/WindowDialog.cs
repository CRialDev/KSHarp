namespace CRial.xbmcgui
{
    public class WindowDialog : WindowBase
    {
        public WindowDialog(string name) : base(name)
        {
        }

        public WindowDialog(int existingWindowId = -1)
            : base()
        {
            Utils.Call(_name + " = WindowDialog(" + existingWindowId + ")");
            Utils.Call(_name + ".winname = '" + _name + "'");
            KSharp.Windows.Add(_name, this);
        }
    }
}