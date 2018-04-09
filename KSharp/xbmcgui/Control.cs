using CRial.Python;
using System;

namespace CRial.xbmcgui
{
    public class Control : PythonObject
    {
        internal bool _enabled = true;
        internal bool _visible = true;
        internal WindowBase _parent;
        //
        public event ControlClickEventHandler OnClick;
        public event ControlFocusEventHandler OnFocus;
        public event ControlDoubleClickEventHandler OnDoubleClick;
        internal void _OnClick(EventArgs e)
        {
            OnClick?.Invoke(this, e);
            Utils.Call("self.EventStarted = False");
        }
        //
        internal Control(string name) : base(name)
        {
            _name = name;
        }
        internal Control() : base("")
        {
            _name = "self.ctl_" + Utils.GenerateId();
        }
        //
        public WindowBase Parent
        {
            get
            {
                return _parent;
            }

        }
        public int Height
        {
            get { return Utils.Call<int>(_name + ".getHeight()"); }
            set { Utils.Call(_name + ".setHeight(" + value + ")"); }
        }
        public int Id
        {
            get
            {
                return Utils.Call<int>(_name + ".getId()");
            }
        }
        public int Width
        {
            get { return Utils.Call<int>(_name + ".getWidth()"); }
            set { Utils.Call(_name + ".setWidth(" + value + ")"); }
        }
        public int X
        {
            get { return Utils.Call<int>(_name + ".getX()"); }
            set { Utils.Call(_name + ".setPosition(" + value + "," + _name + ".getY())"); }
        }
        public int Y
        {
            get { return Utils.Call<int>(_name + ".getY()"); }
            set { Utils.Call(_name + ".setPosition(" + _name + ".getX()," + value + ")"); }
        }
        public bool Enabled
        {
            set { _enabled = value; Utils.Call(_name + ".setEnabled(" + _enabled.ToString() + ")"); }
            get { return _enabled; }
        }
        public bool Visible
        {
            set { _visible = value; Utils.Call(_name + ".setVisible(" + _visible.ToString() + ")"); }
            get { return _visible; }
        }
        //
        public void setNavigation(Control up, Control down, Control left, Control right)
        {
            Utils.Call(_name + ".setNavigation(" + up._name + "," + down._name + "," + left._name + "," + right._name + ")");
        }
        public void controlDown(Control ctl)
        {
            Utils.Call(_name + ".controlDown(" + ctl._name + ")");
        }
        public void controlLeft(Control ctl)
        {
            Utils.Call(_name + ".controlLeft(" + ctl._name + ")");
        }
        public void controlRight(Control ctl)
        {
            Utils.Call(_name + ".controlRight(" + ctl._name + ")");
        }
        public void controlUp(Control ctl)
        {
            Utils.Call(_name + ".controlUp(" + ctl._name + ")");
        }
        ~Control()
        {
            KSharp.Controls.Remove(Id);
            Utils.Call("del " + _name);
        }

        internal void _OnFocus(EventArgs eventArgs)
        {
            OnFocus?.Invoke(this, eventArgs);
            Utils.Call("self.EventStarted = False");

        }
        internal void _OnDoubleClick(EventArgs eventArgs)
        {
            OnDoubleClick?.Invoke(this, eventArgs);
            Utils.Call("self.EventStarted = False");

        }

    }
}