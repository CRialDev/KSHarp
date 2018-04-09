namespace CRial.xbmcplugin
{
    public struct ContentType
    {
        private string _value;
        //
        public ContentType(string value)
        {
            this._value = value;
        }
        public string Value
        {
            get { return _value; }
        }
        //
        public static implicit operator string(ContentType value)
        {
            //return _ContentType[value];
            return value._value;
        }
        //
        public static ContentType Files = new ContentType("files");
        public static ContentType Songs = new ContentType("songs");
        public static ContentType Artists = new ContentType("artists");
        public static ContentType Albums = new ContentType("albums");
        public static ContentType Movies = new ContentType("movies");
        public static ContentType TvShows = new ContentType("tvshows");
        public static ContentType Episodes = new ContentType("episodes");
        public static ContentType MusicVideos = new ContentType("musicvideos");
    }
}
