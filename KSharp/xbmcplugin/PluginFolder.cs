using CRial.Python;
using System;
using System.Collections.Generic;

namespace CRial.xbmcplugin
{
    public class PluginFolder : PluginItem
    {
        internal Dictionary<string, PluginItem> Items = new Dictionary<string, PluginItem>();

        public event ItemSelectedEventHandler OnSelect;
        internal PluginFolder(string label) : base(label, true)
        {
        }
        public PluginFolder CreateDirectory(string label)
        {
            PluginFolder it = new PluginFolder(label);
            it._url = _url + "/" + label;
            it._isFolder = true;
            Items.Add(label, it);
            return it;
        }

        internal PluginFile CreateFile(string label, string fileUrl = "")
        {
            PluginFile it = new PluginFile(label, fileUrl);
            it._url = _url + "/" + label;
            Items.Add(label, it);
            return it;
        }

        internal override void Request()
        {
            OnSelect?.Invoke(this, new EventArgs());
            foreach (PluginItem it in Items.Values)
            {
                Plugin.addDirectoryItem(Convert.ToInt32(Sys.argv[1]), Sys.argv[0], it);
            }
            Plugin.endOfDirectory(Convert.ToInt32(Sys.argv[1]));
        }
        public PluginItem this[string label]
        {
            get
            {
                return Items[label];
            }
        }

    }
}