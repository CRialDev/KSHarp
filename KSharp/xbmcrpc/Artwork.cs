using CRial.Python;

namespace CRial.xbmcrpc
{
    public class Artwork : PythonObject
    {
        internal Artwork(string name) : base(name)
        {
            _name = name;
        }
        public Artwork() : base("")
        {
        }
        public string Banner = "";
        public string Fanart = "";
        public string Poster = "";
        public string Thumb = "";
    }
}
