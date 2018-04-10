using CRial.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcrpc
{
    public class Movie : PythonObject
    {
        public int Id;
        public string Label;
        //
        public Movie(int movieId) : base("")
        {
            Id = movieId;
        }
        internal Movie(int movieId, string label):base("")
        {
            Id = movieId;
            Label = label;
        }
        private T Get<T>(string Prop)
        {
            if (typeof(T) == typeof(Resume))
            {
                string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetMovieDetails', 'params': {'properties': ['" + Prop + "'], 'movieid': " + Id + " }}");
                Resume a = new Resume();
                a.Position = Utils.Call<float>(json + "['result']['moviedetails']['" + Prop + "'].get('position',0)");
                a.Total = Utils.Call<float>(json + "['result']['moviedetails']['" + Prop + "'].get('total',0)");
                return (T)(object)a;
            }
            else if (typeof(T) == typeof(Artwork))
            {
                string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetMovieDetails', 'params': {'properties': ['" + Prop + "'], 'movieid': " + Id + " }}");
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
                return Utils.Call<T>("json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetMovieDetails', 'params': {'properties': ['" + Prop + "'], 'movieid': " + Id + " }})))['result']['moviedetails'].get('" + Prop + "'," + RetIfNull + ")");
            }
        }
        private List<T> GetList<T>(string Prop)
        {
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.GetMovieDetails', 'params': {'properties': ['" + Prop + "'], 'movieid': " + Id + " }}");
            List<T> ret;
            if (typeof(T) == typeof(Actor))
            {
                ret = new List<T>();
                Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['moviedetails']['" + Prop + "']");
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
                ret = new Array<T>(json + "['result']['moviedetails']['" + Prop + "']").ToList();
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
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.SetMovieDetails', 'params': { 'movieid' : " + Id + ", '" + Prop + "' : " + PValue + " }, 'id': 'libMovies'})))");
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
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.SetMovieDetails', 'params': { 'movieid' : " + Id + ", '" + Prop + "' : [" + PValue + "] }, 'id': 'libMovies'})))");
        }
        public bool Remove()
        {
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'id': 1, 'method': 'VideoLibrary.RemoveMovie', 'params': {'movieid': " + Id + " }})))");
        }
        //
        /*public Video.Resume Resume
{
    get
    {
        return new Video.Resume(_name + "['resume']");
    }
}*/
        //public Media.UniqueID uniqueid { get; }*/
        //public Video.Stream streamdetails
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
        public Resume Resume
        {
            get
            {
                return Get<Resume>("resume");
            }
        }

        public List<Actor> Cast
        {
            get
            {
                return GetList<Actor>("cast");
            }
        }
        public List<string> Country
        {
            set
            {
                SetList<string>("country", value);
            }
            get
            {
                return GetList<string>("country");
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
        public List<string> ShowLink
        {
            set
            {
                SetList<string>("showlink", value);
            }
            get
            {
                return GetList<string>("showlink");
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
        public int Year
        {
            get
            {
                return Get<int>("year");
            }
            set
            {
                SetP<int>("year", value);
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
        public string PlotOutline
        {
            set
            {
                SetP<string>("plotoutline", value);
            }
            get
            {
                return Get<string>("plotoutline");
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
        public string Set
        {
            set
            {
                SetP<string>("set", value);
            }
            get
            {
                return Get<string>("set");
            }
        }
        public int SetId
        {
            set
            {
                SetP<int>("setid", value);
            }
            get
            {
                return Get<int>("setid");
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
        public string TagLine
        {
            set
            {
                SetP<string>("tagline", value);
            }
            get
            {
                return Get<string>("tagline");
            }
        }
        public int Top250
        {
            set
            {
                SetP<int>("top250", value);
            }
            get
            {
                return Get<int>("top250");
            }
        }
        public string Trailer
        {
            set
            {
                SetP<string>("trailer", value);
            }
            get
            {
                return Get<string>("trailer");
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
