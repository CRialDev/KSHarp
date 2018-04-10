using CRial;
using CRial.xbmcgui;
using CRial.xbmcplugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplePluginExample myplug = new SimplePluginExample();
        }
    }
    public class SimplePluginExample : KSharp
    {
        public SimplePluginExample() : base()
        {
            Plugin Root = new Plugin(ContentType.Movies);
            //
            PluginFolder MyFirstDirectory = Root.CreateDirectory("My First Directory");
            PluginFolder MySecondDirectory = Root.CreateDirectory("My Second Directory");
            PluginFile MyFirstFile = Root.CreateFile("My File");
            //
            PluginFile MyFirstDirectory_MyFile = MyFirstDirectory.CreateFile("My File");
            //
            MyFirstDirectory.OnSelect += OnSelect;
            MySecondDirectory.OnSelect += OnSelect;
            MyFirstFile.OnSelect += OnSelect;
            MyFirstDirectory_MyFile.OnSelect += OnSelect;
            //
            Root.Tread();
        }

        private void OnSelect(PluginItem sender, EventArgs e)
        {
            Dialog.Notification("PluginExample", sender.Label + " Clicked !");
        }
    }
}
