using CRial.Python;
using System.Collections.Generic;

namespace CRial.xbmcrpc
{
    public class Season : PythonObject
    {
        public int EpisodeCount;
        public int Id;
        public int SeasonNumber;
        public string ShowTitle;
        public int TvShowId;
        public int WatchedEpisodes;

        public Season( int seasonid, int tvshowId) : base("")
        {
            Id = seasonid;
            TvShowId = tvshowId;
        }
        internal Season(string name) : base(name)
        {
        }
        public List<Episode> GetEpisodes(int StartIndex = 0, int Count = 0)
        {
            List<Episode> Ep = new List<Episode>();
            string limit = "";
            if (Count > 0)
                limit = "'limits': { 'start' : " + StartIndex + ", 'end': " + (StartIndex + Count) + " } ";
            string json = Xbmc.ExecuteJSONRPC("{'jsonrpc': '2.0', 'method': 'VideoLibrary.GetEpisodes', 'params': { 'tvshowid' : " + TvShowId + ", 'season' : " + SeasonNumber + ", " + limit + "}, 'id': 'libMovies'}");
            Array<PythonObject> mov = new Array<PythonObject>(json + "['result']['episodes']");
            foreach (PythonObject m in mov)
            {
                int id = Utils.Call<int>(m._name + ".get('episodeid',0)");
                string label = Utils.Call<string>(m._name + ".get('label','')");
                Ep.Add(new Episode(id, label, Id, TvShowId));
            }
            Utils.Call("del " + json);
            return Ep;
        }
    }
}
