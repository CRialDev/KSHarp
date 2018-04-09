using CRial;
using CRial.xbmcgui;
using CRial.xbmcplugin;
using System;
using System.Collections.Generic;

namespace CRial
{
    #region Monitor
    //
    public delegate void OnSettingsChangedEventHandler(Monitor sender);
    public delegate void OnScreensaverActivatedEventHandler(Monitor sender);
    public delegate void OnScreensaverDeactivatedEventHandler(Monitor sender);
    public delegate void OnCleanStartedEventHandler(Monitor sender, LibraryType library);
    public delegate void OnCleanFinishedEventHandler(Monitor sender, LibraryType library);
    public delegate void OnScanStartedEventHandler(Monitor sender, LibraryType library);
    public delegate void OnScanFinishedEventHandler(Monitor sender, LibraryType library);
    public delegate void OnNotificationEventHandler(Monitor sender, string nsender, string method, string data);
    public delegate void OnDPMSDeactivatedEventHandler(Monitor sender);
    public delegate void OnDPMSActivatedEventHandler(Monitor sender);
    //
    #endregion
    //
    #region Player
    /*
    public delegate void OnPlayBackStartedEventHandler(Player sender, EventArgs e);
    public delegate void OnPlayBackEndedEventHandler(Player sender, EventArgs e);
    public delegate void OnPlayBackStoppedEventHandler(Player sender, EventArgs e);
    public delegate void OnPlayBackPausedEventHandler(Player sender, EventArgs e);
    public delegate void OnPlayBackResumedEventHandler(Player sender, EventArgs e);
    public delegate void OnPlayBackSeekEventHandler(Player sender, int time);
    public delegate void OnPlayBackSeekChapterEventHandler(Player sender, int chapter);
    public delegate void OnPlayBackSpeedChangedEventHandler(Player sender, int speed);
    public delegate void OnQueueNextItemEventHandler(Player sender, EventArgs e);
    */
    #endregion
    //
    #region Gui
    //
    public delegate void WindowActionEventHandler(WindowBase sender, ActionEventArgs e);
    public delegate void WindowInitEventHandler(WindowBase sender);
    public delegate void ControlClickEventHandler(Control sender, EventArgs e);
    public delegate void ControlFocusEventHandler(Control sender, EventArgs e);
    public delegate void ControlDoubleClickEventHandler(Control sender, EventArgs e);
    //
    #endregion
    //
    #region Plugin
    //
    public delegate void ItemSelectedEventHandler(PluginItem sender, EventArgs e);
    //
    #endregion
    //
    #region Communication 
        //
    public delegate void OnMessageReceveidEventHandler(string addonId, string msg);
    public delegate void OnCommandReceveidEventHandler(string addonId, string Cmd, Dictionary<string,string> Args);
    //
    #endregion

}
