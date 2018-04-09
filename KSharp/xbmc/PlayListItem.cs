using CRial.Python;

namespace CRial
{
    public class PlayListItem : PythonObject
    {
        internal PlayListItem(string name) : base(name)
        {
            _name = name;
        }
        //
        public string Getdescription()
        {
            return Utils.Call<string>(_name + ".getdescription()");
        }
        public long Getduration()
        {
            return Utils.Call<long>(_name + ".getduration()");
        }
        public string Getfilename()
        {
            return Utils.Call<string>(_name + ".getfilename()");
        }
        ~PlayListItem()
        {
            Utils.Call("del " + _name);
        }
    }
}
