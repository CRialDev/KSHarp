using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public class WindowXmlDialog : WindowXmlBase
    {
        public WindowXmlDialog(string name) : base(name)
        {
        }

        public WindowXmlDialog(string xmlFilename, string scriptPath,string  defaultSkin= "Default", string defaultRes= "720p", bool isMedia= false) : base()
        {
            Utils.Call(_name + " = WindowXMLDialog('" + xmlFilename+"', '"+scriptPath+"', defaultSkin = '"+defaultSkin+"', defaultRes = '"+defaultRes+"', isMedia = "+isMedia.ToString()+")");
            Utils.Call(_name + ".winname = '" + _name + "'");
            KSharp.Windows.Add(_name, this);
        }
    }
}