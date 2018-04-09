using CRial.Python;

namespace CRial.xbmcgui
{
    public class DialogProgressBG : PythonObject
    {
        public DialogProgressBG() : base("")
        {
            _name = "self.dpbg_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmcgui.DialogProgressBG()");
        }

        public DialogProgressBG(string name) : base(name)
        {
            name = _name;
        }

        //
        public void close()
        {
            Utils.Call(_name + ".close()");
        }
        public void create(string heading, string message = "")
        {
            Utils.Call(_name + ".create('" + heading + "', message='" + message + "')");
        }
        public bool isFinished()
        {
            return Utils.Call<bool>(_name + ".isFinished()");
        }
        public void update(int percent, string heading = "", string message = "")
        {
            Utils.Call(_name + ".update(" + percent + ", heading='" + heading + "', message='" + message + "')");
        }
        ~DialogProgressBG()
        {
            Utils.Call("del " + _name);
        }

    }
}
