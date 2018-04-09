using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public class Spin : Control
    {
        internal Spin(string name):base(name)
        { }
        public void setTextures(string up,string down,string upFocus,string downFocus)
        {
            Utils.Call(_name + ".setTextures('"+ up+ "','" + down + "', '" +  upFocus + "','" +  downFocus + "')");
        }
    }
}
