using CRial.Python;
using System.Collections.Generic;

namespace CRial.xbmcrpc
{
    public class Episode : PythonObject
    {
        public int Id;
        public string Label;
        public int SeasonId;
        public int TvShowId;
        private T Get<T>(string Prop)
        {
            if (typeof(T) == typeof(Resume))
            {
                string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetEpisodeDetails', 'params': {'properties': ['" + Prop + "'], 'episodeid': " + Id + " }}");
                Resume a = new Resume();
                a.Position = Utils.Call<float>(json + "['result']['episodedetails']['" + Prop + "'].get('position',0)");
                a.Total = Utils.Call<float>(json + "['result']['episodedetails']['" + Prop + "'].get('total',0)");
                return (T)(object)a;
            }
            else if (typeof(T) == typeof(Artwork))
            {
                string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetEpisodeDetails', 'params': {'properties': ['" + Prop + "'], 'episodeid': " + Id + " }}");
                Artwork a = new Artwork();
                a.Banner = Utils.Call<string>(json + "['result']['episodedetails']['" + Prop + "'].get('banner','')");
                a.Fanart = Utils.Call<string>(json + "['result']['episodedetails']['" + Prop + "'].get('fanart','')");
                a.Poster = Utils.Call<string>(json + "['result']['episodedetails']['" + Prop + "'].get('poster','')");
                a.Thumb = Utils.Call<string>(json + "['result']['episodedetails']['" + Prop + "'].get('thumb','')");
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
                return Utils.Call<T>("json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetEpisodeDetails', 'params': {'properties': ['" + Prop + "'], 'episodeid': " + Id + " }})))['result']['episodedetails'].get('" + Prop + "'," + RetIfNull + ")");
            }
        }
        private List<T> GetList<T>(string Prop)
        {
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetEpisodeDetails', 'params': {'properties': ['" + Prop + "'], 'episodeid': " + Id + " }}");
            List<T> ret;
            if (typeof(T) == typeof(Actor))
            {
                ret = new List<T>();
                Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['episodedetails']['" + Prop + "']");
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
                ret = new Array<T>(json + "['result']['episodedetails']['" + Prop + "']").ToList();
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
            else if (typeof(T) == typeof(Resume))
            {
                PValue = "{ 'position' : " + ((Resume)(object)Value).Position + ", 'total' : " + ((Resume)(object)Value).Total + "}";
            }
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.SetEpisodeDetails', 'params': { 'episodeid' : " + Id + ", '" + Prop + "' : " + PValue + " }, 'id': 'libMovies'})))");
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
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.SetEpisodeDetails', 'params': { 'episodeid' : " + Id + ", '" + Prop + "' : [" + PValue + "] }, 'id': 'libMovies'})))");
        }
        public Episode(int id, string label, int seasonid, int tvshowid) : base("")
        {
            Id = id;
            Label = label;
            SeasonId = seasonid;
            TvShowId = tvshowid;
        }
        internal Episode(string name) : base(name)
        {
        }
        public bool Remove()
        {
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.RemoveEpisode', 'params': {'episodeid': " + Id + " }})))");
        }

        public List<Actor> Cast
        {
            get
            {
                return GetList<Actor>("cast");
            }
        }
        public Resume Resume
        {
            get
            {
                return Get<Resume>("resume");
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
        public int EpisodeNumber
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
        public string Firstaired
        {
            set
            {
                SetP<string>("firstaired", value);
            }
            get
            {
                return Get<string>("firstaired");
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
        public int SeasonNumber
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
        public string ShowTitle
        {
            set
            {
                SetP<string>("showtitle", value);
            }
            get
            {
                return Get<string>("showtitle");
            }
        }
        public int SpecialSortEpisode
        {
            set
            {
                SetP<int>("specialsortepisode", value);
            }
            get
            {
                return Get<int>("specialsortepisode");
            }
        }
        public int SpecialSortSeason
        {
            set
            {
                SetP<int>("specialsortseason", value);
            }
            get
            {
                return Get<int>("specialsortseason");
            }
        }
        public List<string> Writer
        {
            set
            {
                SetList<string>("writer", value);
            }
            get
            {
                return GetList<string>("writer");
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
        public string ProductionCode
        {
            set
            {
                SetP<string>("productioncode", value);
            }
            get
            {
                return Get<string>("productioncode");
            }
        }
        public List<string> director
        {
            set
            {
                SetList<string>("director", value);
            }
            get
            {
                return GetList<string>("director");
            }
        }
        public int RunTime
        {
            set
            {
                SetP<int>("runtime", value);
            }
            get
            {
                return Get<int>("runtime");
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
