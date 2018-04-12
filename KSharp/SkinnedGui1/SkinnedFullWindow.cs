using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.SkinnedGui
{
    public class SkinnedFullWindow : SkinnedWindow
    {
        public SkinnedFullWindow(string title)
        {
            Utils.Call(_name + " = Window()");
            Utils.Call(_name + ".winname = '" + _name + "'");
            KSharp.Windows.Add(_name, this);
            setFrame(title);
        }
    }
}
