using CRial.Python;
using System.Collections.Generic;

namespace CRial.xbmcrpc
{
    public class List
    {
        public class Sort
        {
            public class Orders
            {
                public static Orders Ascending = new Orders("ascending");
                public static Orders Descending = new Orders("descending");
                //
                internal string _value;
                internal Orders(string value)
                {
                    _value = value;
                }
                //
                public static implicit operator string(Orders value)
                {
                    return value._value;
                }

            }
            public class Methods
            {
                public static Methods None = new Methods("none");
                public static Methods Label = new Methods("label");
                public static Methods Date = new Methods("date");
                public static Methods Size = new Methods("size");
                public static Methods File = new Methods("file");
                public static Methods Path = new Methods("path");
                public static Methods DriveType = new Methods("drivetype");
                public static Methods Title = new Methods("title");
                public static Methods Track = new Methods("track");
                public static Methods Time = new Methods("time");
                public static Methods Artist = new Methods("artist");
                public static Methods Album = new Methods("album");
                public static Methods AlbumType = new Methods("albumtype");
                public static Methods Genre = new Methods("genre");
                public static Methods Country = new Methods("country");
                public static Methods Year = new Methods("year");
                public static Methods Rating = new Methods("rating");
                public static Methods Votes = new Methods("votes");
                public static Methods Top250 = new Methods("top250");
                public static Methods ProgramCount = new Methods("programcount");
                public static Methods Playlist = new Methods("playlist");
                public static Methods Episode = new Methods("episode");
                public static Methods Season = new Methods("season");
                public static Methods TotalEpisodes = new Methods("totalepisodes");
                public static Methods WatchedEpisodes = new Methods("watchedepisodes");
                public static Methods TvShowStatus = new Methods("tvshowstatus");
                public static Methods TvShowTitle = new Methods("tvshowtitle");
                public static Methods SortTitle = new Methods("sorttitle");
                public static Methods ProductionCode = new Methods("productioncode");
                public static Methods MPAA = new Methods("mpaa");
                public static Methods Studio = new Methods("studio");
                public static Methods DateAdded = new Methods("dateadded");
                public static Methods LastPlayed = new Methods("lastplayed");
                public static Methods Playcount = new Methods("playcount");
                public static Methods Listeners = new Methods("listeners");
                public static Methods Bitrate = new Methods("bitrate");
                public static Methods Random = new Methods("random");
                //
                internal string _value;
                internal Methods(string value)
                {
                    _value = value;
                }
                //
                public static implicit operator string(Methods value)
                {
                    return value._value;
                }
            }

            public Sort(Methods method, Orders order, bool ignoreArticle = false)
            {
                Method = method;
                Order = order;
                IgnoreArticle = ignoreArticle;
            }
            public bool IgnoreArticle { get; set; } = false;
            public Methods Method { get; set; } = Methods.None;
            public Orders Order { get; set; } = Orders.Ascending;
            //
            public static implicit operator string(Sort value)
            {
                if (value.Method == Methods.None)
                    return "";
                else
                    return ",'sort': { 'order': '" + value.Order + "', 'method': '" + value.Method + "', 'ignorearticle': " + value.IgnoreArticle.ToString() + " } ";
            }
            public static Sort Empty = new Sort(Methods.None, Orders.Ascending);

        }
    }
    public class VideoLibrary
    {
        public VideoLibrary()
        {
        }
        public List<Movie> GetMovies(int StartIndex = 0, int Count = 0)
        {
            List<Movie> Movies = new List<Movie>();
            string limit = "";
            if (Count > 0)
                limit = "'params': { 'limits': { 'start' : " + StartIndex + ", 'end': " + (StartIndex + Count) + " }}, ";
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'method': 'VideoLibrary.GetMovies', " + limit + "'id': 'libMovies'}");
            Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['movies']");
            foreach (PythonObject m in mov)
            {
                int id = Utils.Call<int>(m._name + ".get('movieid',0)");
                string lab = Utils.Call<string>(m._name + ".get('label','')");
                Movies.Add(new Movie(id, lab));
            }
            Utils.Call("del " + json);
            return Movies;
        }
        public List<TVShow> GetTVShows(int StartIndex = 0, int Count = 0)
        {
            List<TVShow> Movies = new List<TVShow>();
            string limit = "";
            if (Count > 0)
                limit = "'params': { 'limits': { 'start' : " + StartIndex + ", 'end': " + (StartIndex + Count) + " }}, ";
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'method': 'VideoLibrary.GetTVShows', " + limit + "'id': 'libTVShows'}");
            Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['tvshows']");
            foreach (PythonObject m in mov)
            {
                int id = Utils.Call<int>(m._name + ".get('tvshowid',0)");
                string lab = Utils.Call<string>(m._name + ".get('label','')");
                Movies.Add(new TVShow(id, lab));
            }
            Utils.Call("del " + json);
            return Movies;
        }
        public bool Clean(bool ShowDialogs)
        {
            return !Utils.Call<bool>("'error' in json.loads(xbmc.executeJSONRPC(json.dumps({'jsonrpc': '2.0', 'method': 'VideoLibrary.Clean', 'params': { 'showdialogs' : " + ShowDialogs.ToString() + " }, 'id': 'libMovies'})))");
        }
        //

    }
}
