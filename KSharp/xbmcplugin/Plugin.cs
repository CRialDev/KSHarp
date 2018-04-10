using CRial.Python;
using CRial.xbmcgui;
using System;
using System.Collections.Generic;

namespace CRial.xbmcplugin
{
    public class Plugin
    {
        internal Dictionary<string, PluginItem> Items = new Dictionary<string, PluginItem>();
        public Plugin(ContentType files)
        {
            PluginFolder Root = new PluginFolder("root");
            Root._url = "root";
            Items.Add("root", Root);
        }
        public PluginFolder CreateDirectory(string label)
        {
            return ((PluginFolder)Items["root"]).CreateDirectory(label);
        }
        public PluginFile CreateFile(string label)
        {
            return ((PluginFolder)Items["root"]).CreateFile(label);
        }
        internal string ParseUrl()
        {
            if (Sys.argv.Count >= 3)
            {
                if (Sys.argv[2].StartsWith("?")) return Sys.argv[2].Substring(1).Replace("%2f", "/").Replace("%20", " ");
                else return "root";
            }
            else return "root";
        }
        public PluginItem GetItem(string url)
        {
            List<string> urls = new List<string>(url.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries));
            if (urls[0] == "root")
            {
                PluginItem ret = this["root"];
                urls.Remove("root");
                foreach (string u in urls)
                    ret = ((PluginFolder)ret)[u];
                return ret;
            }
            else
                throw new Exception("Non root Url");
        }
        public void Tread()
        {
            GetItem(ParseUrl()).Request();
        }
        public PluginItem this[string label]
        {
            get
            {
                return Items[label];
            }
        }
        //
        //
        public static void addDirectoryItem(int handle, string baseUrl, PluginItem it)
        {
            Utils.Call("xbmcplugin.addDirectoryItem(" + handle + ", '" + baseUrl + "?" + it._url + "', " + it._li._name + ", isFolder=" + it._isFolder.ToString() + ")");
        }
        public static void addDirectoryItems(int handle, string baseUrl, List<PluginItem> items)
        {
            foreach (PluginFolder item in items)
                addDirectoryItem(handle, baseUrl, item);
        }
        public static void endOfDirectory(int handle, bool succeeded = true, bool updateListing = false, bool cacheToDisc = true)
        {
            Utils.Call("xbmcplugin.endOfDirectory(" + handle + ", succeeded=" + succeeded.ToString() + ", updateListing=" + updateListing.ToString() + ", cacheToDisc=" + cacheToDisc.ToString() + ")");
        }
        public static void setResolvedUrl(int handle, bool succeeded, ListItem listitem)
        {
            Utils.Call("xbmcplugin.setResolvedUrl(" + handle + ", " + succeeded.ToString() + ", " + listitem._name + ")");
        }
        public static void addSortMethod(int handle, SortMethod sortMethod, string label2Mask = "")
        {
            Utils.Call("xbmcplugin.addSortMethod(" + handle + ", " + (int)sortMethod + ", label2Mask='" + label2Mask + "')");
        }
        public static string getSetting(int handle, string id)
        {
            return Utils.Call<string>("xbmcplugin.getSetting(" + handle + ",'" + id + "')");
        }
        public static void setSetting(int handle, string id, string value)
        {
            Utils.Call("xbmcplugin.setSetting(" + handle + ",'" + id + "','" + value + "')");
        }
        public static void setContent(int handle, ContentType content)
        {
            Utils.Call("xbmcplugin.setContent(" + handle + ",'" + content + "')");
        }
        public static void setPluginCategory(int handle, string category)
        {
            Utils.Call("xbmcplugin.setPluginCategory(" + handle + ",'" + category + "')");
        }
        public static void setPluginFanart(int handle, string image)
        {
            Utils.Call("xbmcplugin.setPluginFanart(" + handle + ",image='" + image + "')");
        }
        public static void setPluginFanart(int handle, string image, Colors color1, Colors color2, Colors color3)
        {
            Utils.Call("xbmcplugin.setPluginFanart(" + handle + ",image='" + image + "',color1='" + color1 + "', color2='" + color2 + "', color3='" + color3 + "')");
        }
        public static void setProperty(int handle, string id, string value)
        {
            Utils.Call("xbmcplugin.setProperty(" + handle + ",'" + id + "','" + value + "')");
        }
        public enum SortMethod : int
        {
            NONE = 0,
            LABEL = 1,
            LABEL_IGNORE_THE = 2,
            DATE = 3,
            SIZE = 4,
            FILE = 5,
            DRIVE_TYPE = 6,
            TRACKNUM = 7,
            DURATION = 8,
            TITLE = 9,
            TITLE_IGNORE_THE = 10,
            ARTIST = 11,
            ARTIST_IGNORE_THE = 12,
            ALBUM = 13,
            ALBUM_IGNORE_THE = 14,
            GENRE = 15,
            VIDEO_YEAR = 16,
            YEAR = 16,
            VIDEO_RATING = 17,
            PROGRAM_COUNT = 18,
            PLAYLIST_ORDER = 19,
            EPISODE = 20,
            VIDEO_TITLE = 21,
            VIDEO_SORT_TITLE = 22,
            VIDEO_SORT_TITLE_IGNORE_THE = 23,
            PRODUCTIONCODE = 24,
            SONG_RATING = 25,
            MPAA_RATING = 26,
            VIDEO_RUNTIME = 27,
            STUDIO = 28,
            STUDIO_IGNORE_THE = 29,
            UNSORTED = 30,
            BITRATE = 31,
            LISTENERS = 32,
            COUNTRY = 33,
            DATEADDED = 34,
            FULLPATH = 35,
            LABEL_IGNORE_FOLDERS = 36,
            LASTPLAYED = 37,
            PLAYCOUNT = 38,
            CHANNEL = 39,
            DATE_TAKEN = 40,
            VIDEO_USER_RATING = 41,
            SONG_USER_RATING = 42
        }
    }
}
