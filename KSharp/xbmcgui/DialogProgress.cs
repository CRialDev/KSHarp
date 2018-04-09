using CRial.Python;

namespace CRial.xbmcgui
{
    public class DialogProgress : PythonObject
    {
        public DialogProgress() : base("")
        {
            _name = "self.dp_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmcgui.DialogProgress()");
        }

        public DialogProgress(string name) : base(name)
        {
            _name = name;
        }

        //
        public void close()
        {
            Utils.Call(_name + ".close()");
        }
        public void create(string heading, string line1 = "", string line2 = "", string line3 = "")
        {
            Utils.Call(_name + ".create('" + heading + "', line1='" + line1 + "', line2='" + line2 + "', line3='" + line3 + "')");
        }
        public bool iscanceled()
        {
            return Utils.Call<bool>(_name + ".iscanceled()");
        }
        public void update(int percent, string line1 = "", string line2 = "", string line3 = "")
        {
            Utils.Call(_name + ".update(" + percent + ", line1='" + line1 + "', line2='" + line2 + "', line3='" + line3 + "')");
        }
        ~DialogProgress()
        {
            Utils.Call("del " + _name);
        }

    }
}
