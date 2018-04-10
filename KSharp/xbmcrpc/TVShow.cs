using CRial.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcrpc
{
    public class TVShow : PythonObject
    {
        public int Id;
        public string Label;
        //
        public TVShow(int tvshowId) : base("")
        {
            Id = tvshowId;
        }
        internal TVShow(int movieId, string label) : base("")
        {
            Id = movieId;
            Label = label;
        }
        private T Get<T>(string Prop)
        {
            if (typeof(T) == typeof(Artwork))
            {
                string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetTVShowDetails', 'params': {'properties': ['" + Prop + "'], 'tvshowid': " + Id + " }}");
                Artwork a = new Artwork();
                a.Banner = Utils.Call<string>(json + "['result']['moviedetails']['" + Prop + "'].get('banner','')");
                a.Fanart = Utils.Call<string>(json + "['result']['moviedetails']['" + Prop + "'].get('fanart','')");
                a.Poster = Utils.Call<string>(json + "['result']['moviedetails']['" + Prop + "'].get('poster','')");
                a.Thumb = Utils.Call<string>(json + "['result']['moviedetails']['" + Prop + "'].get('thumb','')");
                return (T)(object)a;
            }
            else
            {
                string RetIfNull = "";
                if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(long))
                {
                    RetIfNull = "0";
                }
                else if (typeof(T) == typeof(string))
                {
                    RetIfNull = "''";
                }
                else if (typeof(T) == typeof(string))
                {
                    RetIfNull = false.ToString();
                }
                return Utils.Call<T>("json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetTVShowDetails', 'params': {'properties': ['" + Prop + "'], 'tvshowid': " + Id + " }})))['result']['tvshowdetails'].get('" + Prop + "'," + RetIfNull + ")");
            }
        }
        private List<T> GetList<T>(string Prop)
        {
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetTVShowDetails', 'params': {'properties': ['" + Prop + "'], 'tvshowid': " + Id + " }}");
            List<T> ret;
            if (typeof(T) == typeof(Actor))
            {
                ret = new List<T>();
                Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['tvshowdetails']['" + Prop + "']");
                foreach (PythonObject m in mov)
                {
                    Actor a = new Actor();
                    a.Name = Utils.Call<string>(m._name + ".get('name','')");
                    a.Order = Utils.Call<int>(m._name + ".get('order',0)");
                    a.Role = Utils.Call<string>(m._name + ".get('role','')");
                    a.Thumbnail = Utils.Call<string>(m._name + ".get('thumbnail','')");
                    ret.Add((T)(object)a);
                }
            }
            else
            {
                ret = new Array<T>(json + "['result']['tvshowdetails']['" + Prop + "']").ToList();
            }
            Utils.Call("del " + json);
            return ret;
        }
        private bool SetP<T>(string Prop, T Value)
        {
            string PValue = "";
            if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(long))
            {
                PValue = "" + Value;
            }
            else if (typeof(T) == typeof(string))
            {
                PValue = "'" + Value + "'";
            }
            else if (typeof(T) == typeof(bool))
            {
                PValue = Value.ToString();
            }
            else if (typeof(T) == typeof(Artwork))
            {
                PValue = "{ 'banner' : '" + ((Artwork)(object)Value).Banner + "', 'fanart' : '" + ((Artwork)(object)Value).Fanart + "', 'poster' : '" + ((Artwork)(object)Value).Poster + "', 'thumb' : '" + ((Artwork)(object)Value).Thumb + "'}";
            }
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.SetTVShowDetails', 'params': { 'tvshowid' : " + Id + ", '" + Prop + "' : " + PValue + " }, 'id': 'libMovies'})))");
        }
        private bool SetList<T>(string Prop, List<T> Value)
        {
            string PValue = "";
            if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(long))
            {
                foreach (T i in Value)
                    PValue += i + ",";
            }
            else if (typeof(T) == typeof(string))
            {
                foreach (T i in Value)
                    PValue += "'" + i + "',";
            }
            else if (typeof(T) == typeof(bool))
            {
                foreach (T i in Value)
                    PValue += i.ToString() + ",";
            }
            else if (typeof(T) == typeof(Actor))
            {
                foreach (T i in Value)
                    PValue += ((Actor)(object)i).ToJsonString() + ",";
            }
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.SetTVShowDetails', 'params': { 'tvshowid' : " + Id + ", '" + Prop + "' : [" + PValue + "] }, 'id': 'libMovies'})))");
        }
        public List<Season> GetSeasons(int StartIndex = 0, int Count = 0)
        {
            List<Season> Movies = new List<Season>();
            string limit = "";
            if (Count > 0)
                limit = "'limits': { 'start' : " + StartIndex + ", 'end': " + (StartIndex + Count) + " } ";
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'method': 'VideoLibrary.GetSeasons', 'params': { 'properties' : ['showtitle', 'season','episode','watchedepisodes'], 'tvshowid' : " + Id + ", " + limit + "}, 'id': 'libMovies'}");
            Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['seasons']");
            foreach (PythonObject m in mov)
            {
                int sId = Utils.Call<int>(m._name + ".get('seasonid','')");
                Season s = new Season(sId, Id);
                s.SeasonNumber = Utils.Call<int>(m._name + ".get('season','')");
                s.ShowTitle = Utils.Call<string>(m._name + ".get('showtitle','')");
                s.EpisodeCount = Utils.Call<int>(m._name + ".get('episode','')");
                s.WatchedEpisodes = Utils.Call<int>(m._name + ".get('watchedepisodes','')");
                Movies.Add(s);
            }
            Utils.Call("del " + json);
            return Movies;
        }
        public bool Remove()
        {
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.RemoveTVShow', 'params': {'tvshowid': " + Id + " }})))");
        }
        public Artwork Art
        {
            set
            {
                SetP<Artwork>("art", value);
            }
            get
            {
                return Get<Artwork>("art");
            }
        }
        public List<Actor> Cast
        {
            get
            {
                return GetList<Actor>("cast");
            }
        }
        public List<string> Genre
        {
            set
            {
                SetList<string>("genre", value);
            }
            get
            {
                return GetList<string>("genre");
            }
        }
        public List<string> Studio
        {
            set
            {
                SetList<string>("studio", value);
            }
            get
            {
                return GetList<string>("studio");
            }
        }
        public List<string> Tag
        {
            set
            {
                SetList<string>("tag", value);
            }
            get
            {
                return GetList<string>("tag");
            }
        }

        public int Year
        {
            set
            {
                SetP<int>("year", value);
            }
            get
            {
                return Get<int>("year");
            }
        }
        public string ImdbNumber
        {
            set
            {
                SetP<string>("imdbnumber", value);
            }
            get
            {
                return Get<string>("imdbnumber");
            }
        }
        public string Mpaa
        {
            set
            {
                SetP<string>("mpaa", value);
            }
            get
            {
                return Get<string>("mpaa");
            }
        }
        public string OriginalTitle
        {
            set
            {
                SetP<string>("originaltitle", value);
            }
            get
            {
                return Get<string>("originaltitle");
            }
        }
        public string Premiered
        {
            set
            {
                SetP<string>("premiered", value);
            }
            get
            {
                return Get<string>("premiered");
            }
        }
        public float Rating
        {
            set
            {
                SetP<float>("rating", value);
            }
            get
            {
                return Get<float>("rating");
            }
        }
        public string SortTitle
        {
            set
            {
                SetP<string>("sorttitle", value);
            }
            get
            {
                return Get<string>("sorttitle");
            }
        }
        public int UserRating
        {
            set
            {
                SetP<int>("userrating", value);
            }
            get
            {
                return Get<int>("userrating");
            }
        }
        public string Votes
        {
            set
            {
                SetP<string>("votes", value);
            }
            get
            {
                return Get<string>("votes");
            }
        }
        public int Episode
        {
            set
            {
                SetP<int>("episode", value);
            }
            get
            {
                return Get<int>("episode");
            }
        }
        public int Season
        {
            set
            {
                SetP<int>("season", value);
            }
            get
            {
                return Get<int>("season");
            }
        }
        public int WatchedEpisodes
        {
            set
            {
                SetP<int>("watchedepisodes", value);
            }
            get
            {
                return Get<int>("watchedepisodes");
            }
        }
        public string EpisodeGuide
        {
            set
            {
                SetP<string>("episodeguide", value);
            }
            get
            {
                return Get<string>("episodeguide");
            }
        }
        public string DateAdded
        {
            set
            {
                SetP<string>("dateadded", value);
            }
            get
            {
                return Get<string>("dateadded");
            }
        }
        public string File
        {
            set
            {
                SetP<string>("file", value);
            }
            get
            {
                return Get<string>("file");
            }
        }
        public string LastPlayed
        {
            set
            {
                SetP<string>("lastplayed", value);
            }
            get
            {
                return Get<string>("lastplayed");
            }
        }
        public string Plot
        {
            set
            {
                SetP<string>("plot", value);
            }
            get
            {
                return Get<string>("plot");
            }
        }
        public string Title
        {
            set
            {
                SetP<string>("title", value);
            }
            get
            {
                return Get<string>("title");
            }
        }
        public int PlayCount
        {
            set
            {
                SetP<int>("playcount", value);
            }
            get
            {
                return Get<int>("playcount");
            }
        }
        public string Fanart
        {
            set
            {
                SetP<string>("fanart", value);
            }
            get
            {
                return Get<string>("fanart");
            }
        }
        public string Thumbnail
        {
            set
            {
                SetP<string>("thumbnail", value);
            }
            get
            {
                return Get<string>("thumbnail");
            }
        }
    }
}
