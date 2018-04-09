using CRial;
using CRial.xbmcaddon;
using CRial.xbmcgui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleAddon myAddon = new SimpleAddon();
        }
    }
    public class SimpleAddon : KSharp
    {
        Addon addon;
        public SimpleAddon():base()
        {
            addon = new Addon();
            if(Dialog.Ok(addon.getAddonInfo("name"),addon.getAddonInfo("path"),"Click ok to show notification"))
            {
                Dialog.Notification(addon.getAddonInfo("name"), "Clicked Ok");
            }
            Stop();
        }
    }
}
