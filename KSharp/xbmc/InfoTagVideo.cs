using CRial.Python;

namespace CRial
{
    public class InfoTagVideo  : PythonObject
    {
        internal InfoTagVideo(string name) : base(name)
        {
            _name = name;
        }
        public string getDirector()
        {
            return Utils.Call<string>(_name + ".getDirector()");
        }
        public string GetWritingCredits()
        {
            return Utils.Call<string>(_name + ".getWritingCredits()");
        }
        public string GetGenre()
        {
            return Utils.Call<string>(_name + ".getGenre()");
        }
        public string GetTagLine()
        {
            return Utils.Call<string>(_name + ".getTagLine()");
        }
        public string GetPlotOutline()
        {
            return Utils.Call<string>(_name + ".getPlotOutline()");
        }
        public string GetPlot()
        {
            return Utils.Call<string>(_name + ".getPlot()");
        }
        public string GetPictureURL()
        {
            return Utils.Call<string>(_name + ".getPictureURL()");
        }
        public string GetTitle()
        {
            return Utils.Call<string>(_name + ".getTitle()");
        }
        public string GetOriginalTitle()
        {
            return Utils.Call<string>(_name + ".getOriginalTitle()");
        }
        public string GetVotes()
        {
            return Utils.Call<string>(_name + ".getVotes()");
        }
        public string GetCast()
        {
            return Utils.Call<string>(_name + ".getCast()");
        }
        public string GetFile()
        {
            return Utils.Call<string>(_name + ".getFile()");
        }
        public string GetPath()
        {
            return Utils.Call<string>(_name + ".getPath()");
        }
        public string GetIMDBNumber()
        {
            return Utils.Call<string>(_name + ".getIMDBNumber()");
        }
        public int GetYear()
        {
            return Utils.Call<int>(_name + ".getYear()");
        }
        public string GetPremiered()
        {
            return Utils.Call<string>(_name + ".getPremiered()");
        }
        public string GetFirstAired()
        {
            return Utils.Call<string>(_name + ".getFirstAired()");
        }
        public float GetRating()
        {
            return Utils.Call<float>(_name + ".getRating()");
        }
        public int GetPlayCount()
        {
            return Utils.Call<int>(_name + ".getPlayCount()");
        }
        public string GetLastPlayed()
        {
            return Utils.Call<string>(_name + ".getLastPlayed()");
        }
        public string GetTVShowTitle()
        {
            return Utils.Call<string>(_name + ".getTVShowTitle()");
        }
        public string GetMediaType()
        {
            return Utils.Call<string>(_name + ".getMediaType()");
        }
        public int GetSeason()
        {
            return Utils.Call<int>(_name + ".getSeason()");
        }
        public int GetEpisode()
        {
            return Utils.Call<int>(_name + ".getEpisode()");
        }
        ~InfoTagVideo()
        {
            Utils.Call("del " + _name);
        }
    }
}
