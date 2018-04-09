using CRial.Python;
using System;
using System.Collections.Generic;

namespace CRial.xbmcgui
{

    public class WindowBase : PythonObject
    {
        public event WindowActionEventHandler OnAction;
        public event WindowInitEventHandler OnInit;
        internal void _OnAction(ActionEventArgs e)
        {
            OnAction?.Invoke(this, e);
            Utils.Call("self.EventStarted = False");
        }
        //
        public WindowBase(string name) : base(name)
        {
            _name = name;
        }

        public WindowBase() : base("")
        {
            _name = "self.win_" + Utils.GenerateId();
        }
        //
        public void show()
        {
            Utils.Call(_name + ".show()");
        }
        public void close()
        {
            Utils.Call(_name + ".close()");
        }
        public void doModal()
        {
            Utils.Call<string>(_name + ".doModal()");
            
        }
        public void addControl(Control pControl)
        {
            Utils.Call(_name + ".addControl(" + pControl._name + ")");
            KSharp.Controls.Add(pControl.Id, pControl);
            pControl._parent = this;
        }
        public void addControls(List<Control> pControls)
        {
            foreach (Control c in pControls)
                addControl(c);
        }
        public Control getControl(int controlId)
        {
            return KSharp.Controls[controlId];
        }
        public void setFocus(Control pControl)
        {
            Utils.Call(_name + ".setFocus(" + pControl._name + ")");
        }
        public void setFocusId(int pControlId)
        {
            Utils.Call(_name + ".setFocusId(" + pControlId + ")");
        }
        public int getFocusId()
        {
            return Utils.Call<int>(_name + ".getFocusId()");
        }
        public Control getFocus()
        {
            return KSharp.Controls[getFocusId()];
        }
        public void removeControl(Control pControl)
        {
            KSharp.Controls.Remove(pControl.Id);
            Utils.Call(_name + ".removeControl(" + pControl._name + ")");
        }
        public void removeControls(List<Control> pControls)
        {
            foreach (Control c in pControls)
                removeControl(c);
        }
        public int getHeight()
        {
            return Utils.Call<int>(_name + ".getHeight()");
        }

        internal void _OnInit()
        {
            OnInit?.Invoke(this);
            Utils.Call("self.EventStarted = False");
        }

        public int getWidth()
        {
            return Utils.Call<int>(_name + ".getWidth()");
        }
        public ResolutionType getResolution()
        {
            return (ResolutionType)Utils.Call<int>(_name + ".getResolution()");
        }
        public void setCoordinateResolution(ResolutionType res)
        {
            Utils.Call(_name + ".setCoordinateResolution(" + (int)res + ")");
        }
        public void setProperty(string key, string value)
        {
            Utils.Call(_name + ".setProperty('" + key + "', '" + value + "')");
        }
        public string getProperty(string key)
        {
            return Utils.Call<string>(_name + ".getProperty('" + key + "')");
        }
        public void clearProperty(string key)
        {
            Utils.Call(_name + ".clearProperty('" + key + "')");
        }
        public void clearProperties()
        {
            Utils.Call(_name + ".clearProperties()");
        }
        ~WindowBase()
        {
            Utils.Call("del " + _name);
            KSharp.Windows.Remove(_name);
        }

    }

}