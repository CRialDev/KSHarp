using CRial.Python;
using System.Collections.Generic;

namespace CRial.xbmcgui
{
    public class ListItem : PythonObject
    {
        public struct StreamInfosType
        {
            private string _name;
            //
            public StreamInfosType(string name)
            {
                this._name = name;
            }
            public string Name
            {
                get { return _name; }
            }
            //
            public static implicit operator string(StreamInfosType value)
            {
                //return _Colors[value];
                return value._name;
            }
            //
            public static StreamInfosType Video = new StreamInfosType("video");
            public static StreamInfosType Audio = new StreamInfosType("audio");
            public static StreamInfosType Subtitle = new StreamInfosType("subtitle");
        }
        public class StreamInfos
        {
            internal StreamInfosType _type;
            internal Dictionary<string, string> _infos = new Dictionary<string, string>();
            internal ListItem _item;
            //
            internal StreamInfos(StreamInfosType type, ListItem item)
            {
                _type = type;
                _item = item;
            }
            //
            public string this[string info]
            {
                get
                {
                    return _infos[info];
                }
                set
                {
                    _infos[info] = value;
                    Utils.Call(_item._name + ".addStreamInfo('" + _type + "', { '" + info + "': '" + value + "' })");
                }
            }
        }
        public class ListItemProperties
        {
            internal ListItem _item;
            //
            internal ListItemProperties(ListItem item)
            {
                _item = item;
            }
            //
            public string this[string key]
            {
                get
                {
                    return Utils.Call<string>(_item._name + ".getProperty('" + key + "')");
                }
                set
                {
                    Utils.Call(_item._name + ".setProperty('" + key + "', '" + value + "')");
                }
            }
        }
        public class Actor
        {
            public string Name = "";
            public string Role = "";
            public string Thumbnail = "";
            public Actor(string name, string role = "", string thumbnail = "")
            {
                Name = name;
                Role = role;
                Thumbnail = thumbnail;
            }
            //
            public static implicit operator string(Actor value)
            {
                //return _Colors[value];
                return "{'name': '" + value.Name + "', 'role': '" + value.Role + "', 'thumbnail': '" + value.Thumbnail + "'}";
            }
        }
        public class Actors
        {
            private ListItem _item;
            private List<Actor> _actors = new List<Actor>();
            internal Actors(ListItem item)
            {
                _item = item;
            }
            public void Add(Actor act)
            {
                _actors.Add(act);
                Utils.Call(_item._name + ".setCast([{'name': '" + act.Name + "', 'role': '" + act.Name + "','thumbnail': '" + act.Thumbnail + "'}])");
            }
            public List<Actor> Get()
            {
                return _actors;
            }
        }
        public class Season
        {
            public int Number;
            public string Name;
            public Season(int number, string name = "")
            {
                Number = number;
                Name = name;
            }
        }
        public class Seasons
        {
            private ListItem _item;
            private List<Season> _seasons = new List<Season>();
            internal Seasons(ListItem item)
            {
                _item = item;
            }
            public void Add(Season sea)
            {
                _seasons.Add(sea);
                Utils.Call(_item._name + ".addSeason(" + sea.Number + ", '" + sea.Name + "')");
            }
            public List<Season> Get()
            {
                return _seasons;
            }
        }

        public class ContextMenu
        {
            internal ListItem _item;
            Dictionary<string, string> _menuItems = new Dictionary<string, string>();
            internal ContextMenu(ListItem item)
            {
                _item = item;
            }
            public string this[string key]
            {
                get
                {
                    return _menuItems[key]; ;
                }
                set
                {
                    _menuItems[key] = value;
                    Utils.Call(_item._name + ".addContextMenuItems([('" + key + "','" + value + "')])");
                }
            }

        }
        //
        public StreamInfos VideoStreamInfos;
        public StreamInfos AudioStreamInfos;
        public StreamInfos SubtitleStreamInfos;
        public ListItemProperties Properties;
        public ContextMenu ContextMenuItems;
        public Actors Cast;
        public Seasons SeasonsInfos;
        //
        internal ListItem(string name) : base(name)
        {
            VideoStreamInfos = new StreamInfos(StreamInfosType.Video, this);
            AudioStreamInfos = new StreamInfos(StreamInfosType.Audio, this);
            SubtitleStreamInfos = new StreamInfos(StreamInfosType.Subtitle, this);
            Properties = new ListItemProperties(this);
            ContextMenuItems = new ContextMenu(this);
            Cast = new Actors(this);
            SeasonsInfos = new Seasons(this);
            _name = name;
        }
        public ListItem(string label, string label2 = "", string path = "") : this("")
        {
            _name = "self.ctl_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmcgui.ListItem(label='" + label + "', label2='" + label2 + "', path='" + path + "')");
        }
        //
        public string Description
        {
            get
            {
                return Utils.Call<string>(_name + ".getdescription()");
            }
        }
        public string Duration
        {
            get
            {
                return Utils.Call<string>(_name + ".getduration()");
            }
        }
        public string FileName
        {
            get
            {
                return Utils.Call<string>(_name + ".getfilename()");
            }
        }
        public string Label
        {
            get
            {
                return Utils.Call<string>(_name + ".getLabel()");
            }
            set
            {
                Utils.Call(_name + ".setLabel('" + value + "'");
            }
        }
        public string Label2
        {
            get
            {
                return Utils.Call<string>(_name + ".getLabel2()");
            }
            set
            {
                Utils.Call(_name + ".setLabel2('" + value + "'");
            }
        }
        public bool Selected
        {
            get
            {
                return Utils.Call<bool>(_name + ".isSelected()");
            }
            set
            {
                Utils.CallDoModal(_name + ".select(" + value.ToString() + ")");
            }
        }
        public string Path
        {
            get
            {
                return Utils.Call<string>(_name + ".getPath()");
            }
            set
            {
                Utils.Call(_name + ".setPath('" + value + "')");
            }
        }
        public string Thumb
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('thumb')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'thumb': '" + value + "'})");
            }
        }
        public string Poster
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('poster')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'poster': '" + value + "'})");
            }
        }
        public string Banner
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('banner')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'banner': '" + value + "'})");
            }
        }
        public string Fanart
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('fanart')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'fanart': '" + value + "'})");
            }
        }
        public string ClearArt
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('clearart')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'clearart': '" + value + "'})");
            }
        }
        public string ClearLogo
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('clearlogo')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'clearlogo': '" + value + "'})");
            }
        }
        public string Landscape
        {
            get
            {
                return Utils.Call<string>(_name + ".getArt('landscape')");
            }
            set
            {
                Utils.Call(_name + ".setArt({ 'landscape': '" + value + "'})");
            }
        }
        public void setUniqueIDs(string imdb = "", string tvdb = "", string tmdb = "", string anidb = "", string defaultrating = "")
        {
            Utils.Call(_name + ".setUniqueIDs({ 'imdb': '" + imdb + "', 'tmdb' : '" + tvdb + "','tmdb': '" + tmdb + "', 'anidb' : '" + anidb + "' }, '" + defaultrating + "')");
        }
        public string getUniqueID(string key)
        {
            return Utils.Call<string>(_name + ".getUniqueID('" + key + "')");
        }
        public float getRating(string key)
        {
            return Utils.Call<float>(_name + ".getRating('" + key + "'");
        }
        public void setRating(string type, float rating, int votes = 0, bool defaultt = false)
        {
            Utils.Call(_name + ".setRating('" + type + "', " + rating + ", votes=" + votes + ", defaultt=" + defaultt.ToString() + ")");
        }
        public int getVotes(string key)
        {
            return Utils.Call<int>(_name + ".getVotes('" + key + "')");
        }
        ~ListItem()
        {
            Utils.Call("del " + _name);
        }

    }
}