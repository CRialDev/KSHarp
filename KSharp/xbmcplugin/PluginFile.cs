using System;

namespace CRial.xbmcplugin
{
    public class PluginFile : PluginItem
    {
        public event ItemSelectedEventHandler OnSelect;
        public string FileUrl = "";
        internal PluginFile(string label, string fileUrl ="") : base(label, false)
        {
            FileUrl = fileUrl;
        }
        internal override void Request()
        {
            OnSelect?.Invoke(this, new EventArgs());
        }
    }
}