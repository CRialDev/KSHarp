using System;

namespace CRial.xbmcgui
{
    public class Window : WindowBase
    {
        public Window(string name) : base(name)
        {
        }

        public Window(int existingWindowId = -1) : base()
        {
            Utils.Call(_name + " = Window(" + existingWindowId + ")");
            Utils.Call(_name + ".winname = '" + _name + "'");
            KSharp.Windows.Add(_name, this);
        }
    }
}