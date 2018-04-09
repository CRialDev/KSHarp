using CRial.Python;
using CRial.xbmcgui;

namespace CRial
{
    public class PlayList : PythonObject
    {
        public PlayList(PlaylistType playList):base("")
        {
            _name = "self.pl_" + Utils.GenerateId();
            Utils.Call(_name + " = xbmc.PlayList("+(int)playList+")");
        }

        public PlayList(string name) : base(name)
        {
            _name = name;
        }

        //
        public ListItem this[int index]
        {
            get
            {
                return new ListItem(_name + "[" + index + "]");
            }
        }
        public int Count
        {
            get
            {
                return Utils.Call<int>("len(" + _name + ")");
            }
        }
        public void Add(string url, ListItem listitem, int index= -1)
        {
            Utils.Call(_name + ".add('" + url + "', " + listitem._name + ", index=" + index + ")");
        }
        public void Add(string url, int index = -1)
        {
            Utils.Call(_name + ".add('" + url + "', index=" + index + ")");
        }
        public bool Load(string filename)
        {
            return Utils.Call<bool>(_name + ".load('" + filename + "')");
        }
        public void Remove(string filename)
        {
            Utils.Call(_name + ".remove('" + filename + "')");
        }
        public void Clear()
        {
            Utils.Call(_name + ".clear()");
        }
        public void Shuffle()
        {
            Utils.Call(_name + ".shuffle()");
        }
        public void Unshuffle()
        {
            Utils.Call(_name + ".unshuffle()");
        }
        public int Size()
        {
            return Utils.Call<int>(_name + ".size()");
        }
        public int Getposition()
        {
            return Utils.Call<int>(_name + ".getposition()");
        }
        public int GetPlayListId()
        {
            return Utils.Call<int>(_name + ".getPlayListId()");
        }
        ~PlayList()
        {
            Utils.Call("del " + _name);
        }
    }
}
