using System.Collections.Generic;

namespace CRial.xbmcgui
{
    public class Dialog
    {
        public enum BrowseDialogType : int
        {
            ShowAndGetDirectory = 0,
            ShowAndGetFile = 1,
            ShowAndGetImage = 2,
            ShowAndGetWriteableDirectory = 3
        }
        public enum InputDialogType : int
        {
            ALPHANUM = 0,
            DATE = 2,
            IPADDRESS = 4,
            NUMERIC = 1,
            PASSWORD = 5,
            TIME = 3
        }
        public enum InputDialogOption : int
        {
            NONE = 0,
            PASSWORD_VERIFY = 1,
            ALPHANUM_HIDE_INPUT = 2
        }
        //
        public static List<string> BrowseMultiple(BrowseDialogType type, string heading, string shares, string mask = "", bool useThumbs = false, bool treatAsFolder = false, string defaultt = "")
        {
            return Utils.CallList<string>("xbmcgui.Dialog().browseMultiple(type=" + (int)type + ", heading='" + heading + "', shares='" + shares + "', mask='" + mask + "', useThumbs=" + useThumbs + ", treatAsFolder=" + treatAsFolder + ", defaultt='" + defaultt + "')");
        }
        public static string BrowseSingle(BrowseDialogType type, string heading, string shares, string mask = "", bool useThumbs = false, bool treatAsFolder = false, string defaultt = "")
        {
            return Utils.Call<string>("xbmcgui.Dialog().browseSingle(type=" + (int)type + ", heading='" + heading + "', shares='" + shares + "', mask='" + mask + "', useThumbs=" + useThumbs + ", treatAsFolder=" + treatAsFolder + ", defaultt='" + defaultt + "')");
        }
        public static string Input(string heading, string defaultt = "", InputDialogType type = InputDialogType.ALPHANUM, InputDialogOption option = InputDialogOption.NONE, int autoclose = 0)
        {
            return Utils.Call<string>("xbmcgui.Dialog().input('" + heading + "','" + defaultt + "', type=" + (int)type + ", option=" + (int)option + ")");
        }
        public static void Notification(string heading, string message, string icon = "", int time = 0, bool sound = true)
        {
            Utils.Call("xbmcgui.Dialog().notification('" + Utils.RemoveDiacritics(heading) + "','" + Utils.RemoveDiacritics(message) + "', icon='" + icon + "', time=" + time + ", sound=" + sound.ToString() + ")");
        }
        public static bool YesNo(string heading, string line1, string line2 = "", string line3 = "", string nolabel = "", string yeslabel = "", int autoclose = 0)
        {
            return Utils.Call<bool>("xbmcgui.Dialog().yesno('" + Utils.RemoveDiacritics(heading) + "', '" + Utils.RemoveDiacritics(line1) + "', line2='" + Utils.RemoveDiacritics(line2) + "', line3='" + Utils.RemoveDiacritics(line3) + "', nolabel='" + Utils.RemoveDiacritics(nolabel) + "', yeslabel='" + Utils.RemoveDiacritics(yeslabel) + "', autoclose=" + autoclose + ")");
        }
        public static bool Ok(string heading, string line1, string line2 = "", string line3 = "")
        {
            return Utils.Call<bool>("xbmcgui.Dialog().ok('" + Utils.RemoveDiacritics(heading) + "', '" + Utils.RemoveDiacritics(line1) + "', line2='" + Utils.RemoveDiacritics(line2) + "', line3='" + Utils.RemoveDiacritics(line3) + "')");
        }
        public static int Select(string heading, List<string> list, int autoclose = 0, int preselect = -1)
        {
            return Utils.Call<int>("xbmcgui.Dialog().select('" + Utils.RemoveDiacritics(heading) + "', " + Utils.ListToString(list) + ", autoclose=" + autoclose + ", preselect=" + preselect + ")");
        }
        public static int ContextMenu(List<string> list)
        {
            return Utils.Call<int>("xbmcgui.Dialog().contextmenu(" + Utils.ListToString(list) + ")");
        }
        public static void TextViewer(string heading, string text)
        {
            Utils.Call("xbmcgui.Dialog().textviewer('" + heading + "','" + text + "')");
        }
        public static List<string> MultiSelect(string heading, List<string> list, int autoclose = 0)
        {
            List<string> ret = new List<string>();
            foreach (int i in Utils.CallList<int>("xbmcgui.Dialog().multiselect('" + heading + "', " + Utils.ListToString(list) + ", autoclose=" + autoclose + ")"))
                ret.Add(list[i]);
            return ret;
        }
    }
}
