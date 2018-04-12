using CRial.xbmcgui;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CRial
{
    public partial class KSharp
    {
        internal static Dictionary<string, Response> Responses = new Dictionary<string, Response>();
        internal static Dictionary<string, WindowBase> Windows = new Dictionary<string, WindowBase>();
        internal static Dictionary<string, Monitor> Monitors = new Dictionary<string, Monitor>();
        //internal static Dictionary<string, Player> Players = new Dictionary<string, Player>();
        internal static Dictionary<int, Control> Controls = new Dictionary<int, Control>();

        private static Thread ListenerThread;
        internal static bool AddonStarted = false;
        //
        internal static void ThreadLoop()
        {
            while (AddonStarted)
            {
                string cmd = Console.ReadLine();
                CommandeType Type = (CommandeType)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[0]);
                #region Response
                if (Type == CommandeType.Response)
                {
                    cmd = cmd.Split(new char[] { ':' }, 2)[1];
                    string _Id = cmd.Split(new char[] { ':' }, 2)[0];
                    Responses[_Id].Value = cmd.Split(new char[] { ':' }, 2)[1];
                    Responses[_Id].AEvent.Set();
                }
                #endregion
                #region Action Event
                else if (Type == CommandeType.ActionEvent)
                {
                    cmd = cmd.Split(new char[] { ':' }, 2)[1];
                    string _WindowName = cmd.Split(new char[] { ':' }, 2)[0];
                    ActionId _ActionId = (ActionId)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                    Task taskA = Task.Run(() => Windows[_WindowName]._OnAction(new ActionEventArgs(_ActionId)));

                }
                #endregion
                #region Window Event
                else if (Type == CommandeType.WindowInitEvent)
                {
                    string _WindowName = cmd.Split(new char[] { ':' }, 2)[1];
                    Task taskA = Task.Run(() => Windows[_WindowName]._OnInit());
                }
                #endregion
                #region Monitor Event
                else if (Type == CommandeType.MonitorEvent)
                {
                    cmd = cmd.Split(new char[] { ':' }, 2)[1];
                    string _MonitorName = cmd.Split(new char[] { ':' }, 2)[0];
                    cmd = cmd.Split(new char[] { ':' }, 2)[1];
                    MonitorEventType _EventType = (MonitorEventType)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[0]);
                    if (_EventType == MonitorEventType.SettingsChanged)
                    {
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnSettingsChanged());
                    }
                    else if (_EventType == MonitorEventType.ScreensaverActivated)
                    {
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnScreensaverActivated());
                    }
                    else if (_EventType == MonitorEventType.ScreensaverDeactivated)
                    {
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnScreensaverDeactivated());
                    }
                    else if (_EventType == MonitorEventType.CleanStarted)
                    {
                        LibraryType _Library = (LibraryType)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnCleanStarted(_Library));
                    }
                    else if (_EventType == MonitorEventType.CleanFinished)
                    {
                        LibraryType _Library = (LibraryType)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnCleanFinished(_Library));
                    }
                    else if (_EventType == MonitorEventType.ScanStarted)
                    {
                        LibraryType _Library = (LibraryType)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnScanStarted(_Library));
                    }
                    else if (_EventType == MonitorEventType.ScanFinished)
                    {
                        LibraryType _Library = (LibraryType)Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnScanFinished(_Library));
                    }
                    else if (_EventType == MonitorEventType.Notification)
                    {
                        cmd = cmd.Split(new char[] { ':' }, 2)[1];
                        string sender = cmd.Split(new char[] { ':' }, 3)[0];
                        string method = cmd.Split(new char[] { ':' }, 3)[1];
                        string data = cmd.Split(new char[] { ':' }, 3)[2];
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnNotification(sender, method, data));
                    }
                    else if (_EventType == MonitorEventType.DPMSActivated)
                    {
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnDPMSActivated());
                    }
                    else if (_EventType == MonitorEventType.DPMSDeactivated)
                    {
                        Task taskA = Task.Factory.StartNew(() => Monitors[_MonitorName]._OnDPMSDeactivated());
                    }
                }
                #endregion
                #region Player Event
                /*else if (cmd.Contains("XbmcPlayerEvent:"))
                {
                    string newcmd = cmd.Replace("XbmcPlayerEvent:", "");
                    string _PlayerName = newcmd.Split(':')[0];
                    string _EventType = newcmd.Replace(_PlayerName + ":", "");
                    if (_EventType.Contains("onPlayBackStarted"))
                    {
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackStarted(new EventArgs()));
                    }
                    else if (_EventType.Contains("onPlayBackEnded"))
                    {
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackEnded(new EventArgs()));
                    }
                    else if (_EventType.Contains("onPlayBackStopped"))
                    {
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackStopped(new EventArgs()));
                    }
                    else if (_EventType.Contains("onPlayBackPaused"))
                    {
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackPaused(new EventArgs()));
                    }
                    else if (_EventType.Contains("onPlayBackResumed"))
                    {
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackResumed(new EventArgs()));
                    }
                    else if (_EventType.Contains("onPlayBackSeek"))
                    {
                        int _time = Convert.ToInt32(_EventType.Replace("onPlayBackSeek:", ""));
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackSeek(_time));
                    }
                    else if (_EventType.Contains("onPlayBackSeekChapter"))
                    {
                        int _chapter = Convert.ToInt32(_EventType.Replace("onPlayBackSeekChapter:", ""));
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackSeekChapter(_chapter));
                    }
                    else if (_EventType.Contains("onPlayBackSpeedChanged"))
                    {
                        int _speed = Convert.ToInt32(_EventType.Replace("onPlayBackSpeedChanged:", ""));
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnPlayBackSpeedChanged(_speed));
                    }
                    else if (_EventType.Contains("onQueueNextItem"))
                    {
                        Task taskA = Task.Factory.StartNew(() => Players[_PlayerName]._OnQueueNextItem(new EventArgs()));
                    }
                }*/
                #endregion
                #region Control Event
                else if (Type == CommandeType.ControlEvent)
                {
                    int _ControlId = Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                    Task taskA = Task.Factory.StartNew(() => Controls[_ControlId]._OnClick(new EventArgs()));
                }
                else if (Type == CommandeType.ControlFocusEvent)
                {
                    int _ControlId = Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                    Task taskA = Task.Factory.StartNew(() => Controls[_ControlId]._OnFocus(new EventArgs()));
                }
                else if (Type == CommandeType.ControleDoubleClickEvent)
                {
                    int _ControlId = Convert.ToInt32(cmd.Split(new char[] { ':' }, 2)[1]);
                    Task taskA = Task.Factory.StartNew(() => Controls[_ControlId]._OnDoubleClick(new EventArgs()));
                }
                #endregion
            }
        }
        //
        public KSharp()
        {
            ListenerThread = new Thread(new ThreadStart(ThreadLoop));
            AddonStarted = true;
            ListenerThread.Start();
        }
        public void Stop()
        {
            AddonStarted = false;
            Utils.Call("self.addonStarted = False");
            ListenerThread.Abort();
        }
        public void Delete(Python.PythonObject obj)
        {
            Utils.Call("del " + obj._name);
        }
        //
        ~KSharp()
        {
            Stop();
        }
    }
}
