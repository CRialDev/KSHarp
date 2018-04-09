using CRial.Python;

namespace CRial
{
    public class Monitor : PythonObject
    {
        public event OnSettingsChangedEventHandler OnSettingsChanged;
        public event OnScreensaverActivatedEventHandler OnScreensaverActivated;
        public event OnScreensaverDeactivatedEventHandler OnScreensaverDeactivated;
        public event OnCleanStartedEventHandler OnCleanStarted;
        public event OnCleanFinishedEventHandler OnCleanFinished;
        public event OnScanStartedEventHandler OnScanStarted;
        public event OnScanFinishedEventHandler OnScanFinished;
        public event OnNotificationEventHandler OnNotification;
        public event OnDPMSDeactivatedEventHandler OnDPMSDeactivated;
        public event OnDPMSActivatedEventHandler OnDPMSActivated;
        //
        public Monitor() : base("")
        {
            _name = "self.mt_" + Utils.GenerateId();
            Utils.Call(_name + " = Monitor()");
            Utils.Call(_name + ".mtname = '" + _name + "'");
            KSharp.Monitors.Add(_name, this);
        }

        public Monitor(string name) : base(name)
        {
            this._name = name;
        }

        public bool WaitForAbort(int timeout = -1)
        {
            return Utils.Call<bool>(_name + ".waitForAbort(timeout=" + timeout + ")");
        }
        public bool AbortRequested()
        {
            return Utils.Call<bool>(_name + ".abortRequested()");
        }
        internal void _OnSettingsChanged()
        {
            OnSettingsChanged?.Invoke(this);
            Utils.Call("self.EventStarted = False");

        }
        internal void _OnScreensaverActivated()
        {
            OnScreensaverActivated?.Invoke(this);
            Utils.Call("self.EventStarted = False");
        }
        internal void _OnScreensaverDeactivated()
        {
            OnScreensaverDeactivated?.Invoke(this);
            Utils.Call("self.EventStarted = False");
        }
        internal void _OnCleanStarted(LibraryType _Library)
        {
            OnCleanStarted?.Invoke(this, _Library);
            Utils.Call("self.EventStarted = False");
        }
        internal void _OnCleanFinished(LibraryType _Library)
        {
            OnCleanFinished?.Invoke(this, _Library);
            Utils.Call("self.EventStarted = False");
        }
        internal void _OnScanStarted(LibraryType _Library)
        {
            OnScanStarted?.Invoke(this, _Library);
            Utils.Call("self.EventStarted = False");
        }
        internal void _OnScanFinished(LibraryType _Library)
        {
            OnScanFinished?.Invoke(this, _Library);
            Utils.Call("self.EventStarted = False");
        }
        internal void _OnNotification(string sender, string method, string data)
        {
            OnNotification?.Invoke(this, sender, method, data);
            Utils.Call("self.EventStarted = False");
        }
        //
        ~Monitor()
        {
            Utils.Call("del " + _name);
            KSharp.Monitors.Remove(_name);
        }

        internal void _OnDPMSActivated()
        {
            OnDPMSActivated?.Invoke(this);
            Utils.Call("self.EventStarted = False");
        }

        internal void _OnDPMSDeactivated()
        {
            OnDPMSDeactivated?.Invoke(this);
            Utils.Call("self.EventStarted = False");
        }
    }
}
