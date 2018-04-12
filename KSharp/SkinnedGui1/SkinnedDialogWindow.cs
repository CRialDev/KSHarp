using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.SkinnedGui
{
    public class SkinnedDialogWindow : SkinnedWindow
    {
        public SkinnedDialogWindow(string title) : base()
        {
            Utils.Call(_name + " = WindowDialog()");
            Utils.Call(_name + ".winname = '" + _name + "'");
            KSharp.Windows.Add(_name, this);
            setFrame(title);
        }
    }
}
