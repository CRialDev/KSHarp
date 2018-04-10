using CRial.xbmcgui;

namespace CRial.xbmcplugin
{
    public class PluginItem
    {
        internal string _url;
        internal string _label;
        internal ListItem _li;
        internal bool _isFolder;

        internal PluginItem(string label, bool isFolder)
        {
            this._label = label;
            _li = new ListItem(label, "");
            _isFolder = isFolder;
        }
        internal virtual void Request() { }
        public string Url
        {
            get
            {
                return _url;
            }
        }
        public string Label
        {
            get
            {
                return _label;
            }
        }
        public ListItem BaseItem
        {
            get
            {
                return _li;
            }
            set
            {
                _li = value;
            }
        }
    }
}