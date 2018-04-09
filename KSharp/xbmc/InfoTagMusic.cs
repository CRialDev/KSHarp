using CRial.Python;

namespace CRial
{
    public class InfoTagMusic : PythonObject
    {
        internal InfoTagMusic(string name) : base(name)
        {
            _name = name;
        }
        //
        public string GetURL()
        {
            return Utils.Call<string>(_name + ".getURL()");
        }
        public string GetTitle()
        {
            return Utils.Call<string>(_name + ".getTitle()");
        }
        public string GetArtist()
        {
            return Utils.Call<string>(_name + ".getArtist()");
        }
        public string GetAlbumArtist()
        {
            return Utils.Call<string>(_name + ".getAlbumArtist()");
        }
        public string GetAlbum()
        {
            return Utils.Call<string>(_name + ".getAlbum()");
        }
        public string GetGenre()
        {
            return Utils.Call<string>(_name + ".getGenre()");
        }
        public int GetDuration()
        {
            return Utils.Call<int>(_name + ".getDuration()");
        }
        public int GetTrack()
        {
            return Utils.Call<int>(_name + ".getTrack()");
        }
        public int GetDisc()
        {
            return Utils.Call<int>(_name + ".getDisc()");
        }
        public int GetTrackAndDisc()
        {
            return Utils.Call<int>(_name + ".getTrackAndDisc()");
        }
        public string GetReleaseDate()
        {
            return Utils.Call<string>(_name + ".getReleaseDate()");
        }
        public int GetListeners()
        {
            return Utils.Call<int>(_name + ".getListeners()");
        }
        public int GetPlayCount()
        {
            return Utils.Call<int>(_name + ".getPlayCount()");
        }
        public string GetLastPlayed()
        {
            return Utils.Call<string>(_name + ".getLastPlayed()");
        }
        public string GetComment()
        {
            return Utils.Call<string>(_name + ".getComment()");
        }
        public string GetLyrics()
        {
            return Utils.Call<string>(_name + ".getLyrics()");
        }
        ~InfoTagMusic()
        {
            Utils.Call("del " + _name);
        }
    }
}
