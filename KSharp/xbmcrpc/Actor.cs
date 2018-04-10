using CRial.Python;

namespace CRial.xbmcrpc
{
    public class Actor : PythonObject
    {
        internal Actor(string name) : base(name)
        {
        }
        public Actor() : base("")
        {
        }
        public string Thumbnail = "";
        public string Role = "";
        public string Name = "";
        public int Order = 0;
        internal string ToJsonString()
        {
            return "{ 'name' : '" + Name + "', 'role' : '" + Role + "', 'thumbnail' : '" + Thumbnail + "', 'order' : " + Order + "}";
        }
    }
}
