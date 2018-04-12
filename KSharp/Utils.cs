using CRial;
using CRial.xbmcaddon;
using CRial.xbmcgui;
using CRial.xbmcvfs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CRial
{
    public class Utils
    {
        internal static string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC)).Replace("'","\\'");
        }
        internal static string GenerateId()
        {
            long ticks = DateTime.Now.Ticks;
            return string.Format("{0:X}", ticks).ToLower();
        }
        internal static string TransformString(string Cmd)
        {
            return Cmd.Replace("\n", "'+NewLine+'");
        }
        internal static bool ToBool(string value)
        {
            switch (value.ToLower())
            {
                case "true":
                    return true;
                case "t":
                    return true;
                case "1":
                    return true;
                case "0":
                    return false;
                case "false":
                    return false;
                case "f":
                    return false;
                default:
                    throw new InvalidCastException("You can't cast a weird value to a bool!");
            }

        }
        internal static T GetFromType<T>(string name)
        {
            if (typeof(T) == typeof(CRial.InfoTagMusic))
            {
                return (T)(object)new CRial.InfoTagMusic(name);
            }
            else if (typeof(T) == typeof(CRial.InfoTagVideo))
            {
                return (T)(object)new CRial.InfoTagVideo(name);
            }
            else if (typeof(T) == typeof(CRial.Keyboard))
            {
                return (T)(object)new CRial.Keyboard(name);
            }
            else if (typeof(T) == typeof(CRial.Monitor))
            {
                return (T)(object)new CRial.Monitor(name);
            }
            else if (typeof(T) == typeof(CRial.PlayList))
            {
                return (T)(object)new CRial.PlayList(name);
            }
            else if (typeof(T) == typeof(CRial.PlayListItem))
            {
                return (T)(object)new CRial.PlayListItem(name);
            }
            else if (typeof(T) == typeof(CRial.Python.PythonObject))
            {
                return (T)(object)new CRial.Python.PythonObject(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcvfs.File))
            {
                return (T)(object)new CRial.xbmcvfs.File(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.WindowXml))
            {
                return (T)(object)new CRial.xbmcgui.WindowXml(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.WindowXmlBase))
            {
                return (T)(object)new CRial.xbmcgui.WindowXmlBase(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.WindowXmlDialog))
            {
                return (T)(object)new CRial.xbmcgui.WindowXmlDialog(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Action))
            {
                return (T)(object)new CRial.xbmcgui.Action(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Button))
            {
                return (T)(object)new CRial.xbmcgui.Button(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Control))
            {
                return (T)(object)new CRial.xbmcgui.Control(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Edit))
            {
                return (T)(object)new CRial.xbmcgui.Edit(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.FadeLabel))
            {
                return (T)(object)new CRial.xbmcgui.FadeLabel(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Image))
            {
                return (T)(object)new CRial.xbmcgui.Image(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Label))
            {
                return (T)(object)new CRial.xbmcgui.Label(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.TextBox))
            {
                return (T)(object)new CRial.xbmcgui.TextBox(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.Window))
            {
                return (T)(object)new CRial.xbmcgui.Window(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.WindowBase))
            {
                return (T)(object)new CRial.xbmcgui.WindowBase(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.WindowDialog))
            {
                return (T)(object)new CRial.xbmcgui.WindowDialog(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.DialogBusy))
            {
                return (T)(object)new CRial.xbmcgui.DialogBusy(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.DialogProgress))
            {
                return (T)(object)new CRial.xbmcgui.DialogProgress(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.DialogProgressBG))
            {
                return (T)(object)new CRial.xbmcgui.DialogProgressBG(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcgui.ListItem))
            {
                return (T)(object)new CRial.xbmcgui.ListItem(name);
            }
            else if (typeof(T) == typeof(CRial.xbmcaddon.Addon))
            {
                return (T)(object)new CRial.xbmcaddon.Addon(name);
            }
           else return (T)(object)null;
        }
        public static Type TypeOf(string PythonObj)
        {
            string t = Utils.Call<string>("str(type(" + PythonObj + "))");
            if (t.Contains("int"))
            {
                return typeof(int);
            }
            else if (t.Contains("str"))
            {
                return typeof(string);
            }
            else if (t.Contains("unicode"))
            {
                return typeof(string);
            }
            else if (t.Contains("basestring"))
            {
                return typeof(string);
            }
            else if (t.Contains("bool"))
            {
                return typeof(bool);
            }
            else if (t.Contains("long"))
            {
                return typeof(long);
            }
            else if (t.Contains("float"))
            {
                return typeof(float);
            }
            else if (t.Contains("list"))
            {
                return typeof(List<object>);
            }
            else if (t.Contains("dict"))
            {
                return typeof(Dictionary<object, object>);
            }
            else if (t.Contains("xbmc.InfoTagMusic"))
            {
                return typeof(InfoTagMusic);
            }
            else if (t.Contains("xbmc.InfoTagVideo"))
            {
                return typeof(InfoTagVideo);
            }
            else if (t.Contains("xbmc.Keyboard"))
            {
                return typeof(Keyboard);
            }
            else if (t.Contains("Monitor"))
            {
                return typeof(Monitor);
            }
            else if (t.Contains("xbmc.PlayList"))
            {
                return typeof(PlayList);
            }
            else if (t.Contains("xbmcgui.Action"))
            {
                return typeof(xbmcgui.Action);
            }
            else if (t.Contains("xbmcgui.DialogProgress"))
            {
                return typeof(DialogProgress);
            }
            else if (t.Contains("xbmcgui.DialogProgressBG"))
            {
                return typeof(DialogProgressBG);
            }
            else if (t.Contains("xbmcgui.ListItem"))
            {
                return typeof(ListItem);
            }
            else if (t.Contains("WindowDialog"))
            {
                return typeof(WindowDialog);
            }
           else if (t.Contains("WindowXMLDialog"))
            {
                return typeof(WindowXmlDialog);
            }
            else if (t.Contains("WindowXML"))
            {
                return typeof(WindowXml);
            }
            else if (t.Contains("Window"))
            {
                return typeof(Window);
            }
            else if (t.Contains("xbmcaddon.Addon"))
            {
                return typeof(Addon);
            }
            else if (t.Contains("xbmcvfs.File"))
            {
                return typeof(File);
            }
            else if (t.Contains("xbmcgui.ControlButton"))
            {
                return typeof(Button);
            }
            else if (t.Contains("xbmcgui.ControlEdit"))
            {
                return typeof(Edit);
            }
            else if (t.Contains("xbmcgui.ControlFadeLabel"))
            {
                return typeof(FadeLabel);
            }
            else if (t.Contains("xbmcgui.ControlImage"))
            {
                return typeof(Image);
            }
            else if (t.Contains("xbmcgui.ControlLabel"))
            {
                return typeof(Label);
            }
            else if (t.Contains("xbmcgui.ControlTextBox"))
            {
                return typeof(TextBox);
            }
            else return null;
        }
        internal static string ListToString(List<string> list)
        {
            string li = "[";
            foreach (string s in list)
            {
                li += "'" + s + "',";
            }
            return li.Substring(0, li.Length - 1) + "]";
        }
        internal static void Call(string Cmd)
        {
            Console.WriteLine("" + TransformString(Cmd));
        }
        public static T Call<T>(string Command)
        {
            string id = GenerateId();
            KSharp.Responses.Add(id, new Response());
            TypeCode t = Type.GetTypeCode(typeof(T));
            T res;
            switch (t)
            {
                case TypeCode.Int32:
                    Call("self.Write('0:" + id + ":'+str(" + TransformString(Command) + "))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    res = (T)(object)Convert.ToInt32(KSharp.Responses[id].Value);
                    break;
                case TypeCode.String:
                    Call("self.Write('0:" + id + ":'+ " + TransformString(Command) + ")");
                    KSharp.Responses[id].AEvent.WaitOne();
                    res = (T)(object)KSharp.Responses[id].Value;
                    break;
                case TypeCode.Boolean:
                    Call("self.Write('0:" + id + ":'+ str(" + TransformString(Command) + "))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    res = (T)(object)ToBool(KSharp.Responses[id].Value);
                    break;
                case TypeCode.Single:
                    Call("self.Write('0:" + id + ":'+ str(" + TransformString(Command) + "))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    res = (T)(object)float.Parse(KSharp.Responses[id].Value, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case TypeCode.Double:
                    Call("self.Write('0:" + id + ":'+ str(" + TransformString(Command) + "))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    res = (T)(object)double.Parse(KSharp.Responses[id].Value, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case TypeCode.Int64:
                    Call("self.Write('0:" + id + ":'+ str(" + TransformString(Command) + "))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    res = (T)(object)Convert.ToInt64(KSharp.Responses[id].Value);
                    break;
                default:
                    res = (T)(object)null;
                    break;
            }
            KSharp.Responses.Remove(id);
            return res;
        }
        internal static List<T> CallList<T>(string Cmd)
        {
            string id = GenerateId();
            KSharp.Responses.Add(id, new Response());
            TypeCode t = Type.GetTypeCode(typeof(T));
            Char delimiter;
            List<string> li;
            List<T> res = new List<T>();
            switch (t)
            {
                case TypeCode.Int32:
                    Console.WriteLine("self.Write('0:" + id + ":'+ str(" + TransformString(Cmd) + ").strip('[]'))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    delimiter = ',';
                    li = new List<string>(KSharp.Responses[id].Value.Replace(" ", "").Split(delimiter));
                    res = new List<T>();
                    foreach (string s in li)
                        res.Add((T)(object)Convert.ToInt32(s));
                    break;
                case TypeCode.String:
                    Call("self.Write('0:" + id + ":'+str('|'.join(" + TransformString(Cmd) + ")))");
                    KSharp.Responses[id].AEvent.WaitOne();
                    delimiter = '|';
                    li = new List<string>(KSharp.Responses[id].Value.Split(delimiter));
                    res = new List<T>();
                    foreach (string s in li)
                        res.Add((T)(object)s);
                    break;
            }
            KSharp.Responses.Remove(id);
            return res;
        }
        internal static void CallDoModal(string Cmd)
        {
            string id = GenerateId();
            KSharp.Responses.Add(id, new Response());
            Call("Commands.put(" + TransformString(Cmd) + ")");
            Call("Commands.put(self.Write('0:" + id + ":True'))");
            KSharp.Responses[id].AEvent.WaitOne();
        }
    }
}