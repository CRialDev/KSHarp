using CRial.Python;

namespace CRial
{
    public class Keyboard : PythonObject
    {
        public Keyboard() : base("")
        {
            _name = "self.kb_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmc.Keyboard()");
        }

        internal Keyboard(string name) : base(name)
        {
            _name = name;
        }

        //
        public void doModal(int autoclose = 0)
        {
            Utils.CallDoModal(_name + ".doModal(autoclose=" + autoclose + ")");
        }
        public void setDefault(string line)
        {
            Utils.Call(_name + ".setDefault('" + line + "')");
        }
        public void setHiddenInput(bool hidden)
        {
            Utils.Call(_name + ".setHiddenInput(" + hidden.ToString() + ")");
        }
        public void setHeading(string heading)
        {
            Utils.Call(_name + ".setHeading('" + heading + "')");
        }
        public string getText()
        {
            return Utils.Call<string>(_name + ".getText()");
        }
        public bool isConfirmed()
        {
            return Utils.Call<bool>(_name + ".isConfirmed()");
        }
        ~Keyboard()
        {
            Utils.Call("del " + _name);
        }

    }
}
