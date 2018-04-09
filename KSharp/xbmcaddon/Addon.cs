using CRial.Python;

namespace CRial.xbmcaddon
{
    public class Addon : PythonObject
    {
        public Addon(string id = "") : base("")
        {
            _name = "self.addon_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmcaddon.Addon(id='" + id + "')");
        }

        public Addon(string name,string Null) : base(name)
        {
            _name = name;
        }

        //
        public string getAddonInfo(string id)
        {
            return Utils.Call<string>(_name + ".getAddonInfo('" + id + "')");
        }
        public string getLocalizedString(int id)
        {
            return Utils.Call<string>(_name + ".getLocalizedString(" + id + ")");
        }
        public string getSetting(string id)
        {
            return Utils.Call<string>(_name + ".getSetting('" + id + "')");
        }
        public void openSettings()
        {
            Utils.Call(_name + ".openSettings()");
        }
        public void setSetting(string id, string value)
        {
            Utils.Call(_name + ".setSetting(id='" + id + "', value='" + value + "')");
        }
        ~Addon()
        {
            Utils.Call("del " + _name);
        }

    }
}
