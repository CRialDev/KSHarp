namespace CRial
{
    internal enum MonitorEventType : int
    {
        SettingsChanged = 0,
        ScreensaverActivated = 1,
        ScreensaverDeactivated = 2,
        CleanStarted = 3,
        CleanFinished = 4,
        ScanStarted = 5,
        ScanFinished = 6,
        Notification = 7,
        DPMSActivated = 8,
        DPMSDeactivated = 9
    }
}
