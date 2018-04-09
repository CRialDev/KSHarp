using CRial.Python;
using System.Collections.Generic;
using System.Threading;

namespace CRial
{
    public partial class Xbmc
    {
        public static void AudioResume()
        {
            Utils.Call("xbmc.audioResume()");
        }
        public static void AudioSuspend()
        {
            Utils.Call("xbmc.audioSuspend()");
        }
        public static void EnableNavSounds(bool enable)
        {
            Utils.Call("xbmc.enableNavSounds("+enable.ToString()+")");
        }
        public static string ExecuteJSONRPC(string jsonrpccommand)
        {
            string json_name = "self.js_" + Utils.GenerateId();
            Utils.Call(json_name + " = json.loads(xbmc.executeJSONRPC(json.dumps(" + jsonrpccommand + ")))");
            return json_name;
        }
        public static void Executescript(string script)
        {
            Utils.Call("xbmc.executescript('" + script + "')");
        }
        public static string ConvertLanguage(string language, LanguageFormat format)
        {
            return Utils.Call<string>("xbmc.convertLanguage('"+language+"', "+(int)format+")");
        }
        public static string GetCacheThumbName(string path)
        {
            return Utils.Call<string>("xbmc.getCacheThumbName('" + path + "')");
        }
        public static string GetCleanMovieTitle(string path, bool usefoldername= false)
        {
            return Utils.Call<string>("xbmc.getCleanMovieTitle('" + path + "', "+usefoldername.ToString()+")");
        }
        public static bool GetCondVisibility(string condition)
        {
            return Utils.Call<bool>("xbmc.getCondVisibility('" + condition + "')");
        }
        public static DVDState GetDVDState()
        {
            return (DVDState)Utils.Call<int>("xbmc.getDVDState()");
        }
        public static int GetFreeMem()
        {
            return Utils.Call<int>("xbmc.getFreeMem()");
        }
        public static int GetGlobalIdleTime()
        {
            return Utils.Call<int>("xbmc.getGlobalIdleTime()");
        }
        public static string GetIPAddress()
        {
            return Utils.Call<string>("xbmc.getIPAddress()");
        }
        public static string GetInfoImage(string infotag)
        {
            return Utils.Call<string>("xbmc.getInfoImage('"+infotag+"')");
        }
        public static string GetInfoLabel(string cLine)
        {
            return Utils.Call<string>("xbmc.getInfoLabel('"+cLine+"')");
        }
        public static string GetLanguage(LanguageFormat format = LanguageFormat.ENGLISH_NAME, bool region= false)
        {
            return Utils.Call<string>("xbmc.getLanguage(format="+(int)format+", region=" + region.ToString()+")");
        }
        public static string GetLocalizedString(int id)
        {
            return Utils.Call<string>("xbmc.getLocalizedString("+id+")");
        }
        public static string GetRegion(string id)
        {
            return Utils.Call<string>("xbmc.getRegion('" + id + "')");
        }
        public static string GetSkinDir()
        {
            return Utils.Call<string>("xbmc.getSkinDir()");
        }
        public static List<string> getSupportedMedia(MediaType mediaType)
        {
            return new List<string>(Utils.Call<string>("xbmc.getSupportedMedia('"+mediaType+"')").Split('|'));  
        }
        public static string makeLegalFilename(string filename, bool fatX = true)
        {
            return Utils.Call<string>("xbmc.makeLegalFilename('" + filename + "', fatX=" + fatX.ToString() + ")");
        }
        public static void PlaySFX(string filename, bool useCached = true)
        {
            Utils.Call("xbmc.playSFX('" + filename + "', useCached=" + useCached.ToString() + ")");
        }
        public static void StopSFX()
        {
            Utils.Call("xbmc.stopSFX()");
        }
        public static void Shutdown()
        {
            Utils.Call("xbmc.shutdown()");
        }
        public static bool SkinHasImage(string image)
        {
            return Utils.Call<bool>("xbmc.skinHasImage('"+image+"')");
        }
        public static void Sleep(int timemillis)
        {
            Utils.Call("xbmc.sleep(" + timemillis + ")");
            Thread.Sleep(timemillis);
        }
        public static bool StartServer(ServerType iTyp,bool bStart, bool bWait= false)
        {
            return Utils.Call<bool>("xbmc.startServer(" + (int)iTyp + ", " + bStart.ToString() + ", bWait=" + bWait.ToString() + ")");
        }
        public static string TranslatePath(string path)
        {
            return Utils.Call<string>("xbmc.translatePath('" + path + "')");
        }
        public static string ValidatePath(string path)
        {
            return Utils.Call<string>("xbmc.validatePath('" + path + "')");
        }
        public static void Executebuiltin(string function)
        {
            Utils.Call("xbmc.executebuiltin('" + function + "')");
        }
        public static void Log(string msg, LogLevel level = LogLevel.LOGNOTICE)
        {
            Utils.Call("xbmc.log('" + Utils.RemoveDiacritics(msg) + "', level=" + (int)level + ")");
        }
        public static void Log(PythonObject obj, LogLevel level = LogLevel.LOGNOTICE)
        {
            Utils.Call("xbmc.log(str(" + obj._name + "), level=" + (int)level + ")");
        }

        public static void Restart()
        {
            Utils.Call("xbmc.restart()");
        }
        //
    }
    //
    public enum ServerType : int
    {
        AIRPLAYSERVER = 2,
        EVENTSERVER = 6,
        JSONRPCSERVER = 3,
        UPNPRENDERER = 4,
        UPNPSERVER = 5,
        WEBSERVER = 1,
        ZEROCONF = 7
    }
    public enum LanguageFormat
    {
        ENGLISH_NAME = 2,
        ISO_639_1 = 0,
        ISO_639_2 = 1
    }
    public struct MediaType
    {
        private string _name;
        //
        public MediaType(string name)
        {
            this._name = name;
        }
        //
        public static implicit operator string(MediaType value)
        {
            //return _Colors[value];
            return value._name;
        }
        //
        public static MediaType Video = new MediaType("video");
        public static MediaType Music = new MediaType("music");
        public static MediaType Picture = new MediaType("picture");
    }
    public enum DVDState : int
    {
        DRIVE_NOT_READY = 1,
        TRAY_OPEN = 16,
        TRAY_CLOSED_NO_MEDIA = 64,
        TRAY_CLOSED_MEDIA_PRESENT = 96
    }
    public enum Alignment : int
    {
        LEFT = 0x00000000, //< Align X left,
        RIGHT = 0x00000001,//< Align X right
        CENTER_X = 0x00000002,//< Align X center
        CENTER_Y = 0x00000004,//< Align Y center
        TRUNCATED = 0x00000008,//< Truncated text
        JUSTIFIED = 0x00000010 //< Justify text
    }
    public enum ResolutionType : int
    {
        INVALID = -1,
        HDTV_1080i = 0,
        HDTV_720pSBS = 1,
        HDTV_720pTB = 2,
        HDTV_1080pSBS = 3,
        HDTV_1080pTB = 4,
        HDTV_720p = 5,
        HDTV_480p_4x3 = 6,
        HDTV_480p_16x9 = 7,
        NTSC_4x3 = 8,
        NTSC_16x9 = 9,
        PAL_4x3 = 10,
        PAL_16x9 = 11,
        PAL60_4x3 = 12,
        PAL60_16x9 = 13,
        AUTORES = 14,
        WINDOW = 15,
        DESKTOP = 16,
        CUSTOM = 17
    }
    public enum LogLevel : int
    {
        LOGDEBUG = 0,
        LOGERROR = 4,
        LOGFATAL = 6,
        LOGINFO = 1,
        LOGNONE = 7,
        LOGNOTICE = 2,
        LOGSEVERE = 5,
        LOGWARNING = 3
    }
    public enum CaptureState : int
    {
        WORKING = 0,
        DONE = 3,
        FAILED = 4
    }
    public enum CaptureFlags : int
    {
        NONE = 0,
        CONTINUOUS = 1,
        IMMEDIATELY = 2
    }
    public enum PlaylistType : int
    {
        Music = 0,
        Video = 1
    }
    public enum AspectRatioType
    {
        Stretch = 0, ScaleUp = 1, ScaleDown = 2
    }
}
