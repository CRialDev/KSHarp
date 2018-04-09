using CRial.Python;

namespace CRial.xbmcgui
{
    public class DialogBusy : PythonObject
    {
        public DialogBusy(string name) : base(name){ }

        public DialogBusy() : base("")
        {
            _name = "self.db_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmcgui.DialogBusy()");
        }
        //
        public void close()
        {
            Utils.Call(_name + ".close()");
        }
        public void create()
        {
            Utils.Call(_name + ".create()");
        }
        public bool iscanceled()
        {
            return Utils.Call<bool>(_name + ".iscanceled()");
        }
        public void update(int percent)
        {
            Utils.Call(_name + ".update(" + percent + ")");
        }
        ~DialogBusy()
        {
            Utils.Call("del " + _name);
        }

    }
}
