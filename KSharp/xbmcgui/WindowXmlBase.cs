using System;
using System.Collections.Generic;
using System.Linq;

namespace CRial.xbmcgui
{
    public class WindowXmlBase : WindowBase
    {

        public WindowXmlBase(string name) : base(name)
        {
        }

        public WindowXmlBase() : base()
        {
        }

        public void RemoveItem(int position)
        {
            Utils.Call(_name + ".removeItem(" + position + ")");
        }
        public void AddItem(string item, int position= 32767)
        {
            Utils.Call(_name + ".addItem('"+item+"',"+position+")");
        }
        public void AddItem(ListItem item, int position = 32767)
        {
            Utils.Call(_name + ".addItem(" + item._name + "," + position + ")");
        }
        public void AddItems(List<object> items)
        {
            var stringList = items.OfType<string>().ToList();
            foreach (string s in stringList)
                AddItem(s);
            var ListItemList = items.OfType<ListItem>().ToList();
            foreach (ListItem s in ListItemList)
                AddItem(s);

        }
        public void ClearList()
        {
            Utils.Call(_name + ".clearList()");
        }
        public ListItem GetListItem(int position)
        {
            string li_name = "self.ctl_" + Utils.GenerateId();
            Utils.Call(li_name+" = "+_name + ".getListItem(" + position + ")");
            return new ListItem(li_name);
        }
        public int GetListSize()
        {
            return Utils.Call<int>(_name + ".getListSize()");
        }
        public void SetContainerProperty(string key, string value)
        {
            Utils.Call(_name + ".setContainerProperty('" + key + "', '" + value + "')");
        }
        public int GetCurrentContainerId()
        {
            return Utils.Call<int>(_name + ".getCurrentContainerId()");
        }
        public void setContent(WindowXmlContentType value)
        {
            Utils.Call(_name + ".setContent('" + value + "')");
        }
        public int CurrentListPosition
        {
            get
            {
                return Utils.Call<int>(_name + ".getCurrentListPosition()");
            }
            set
            {
                Utils.Call(_name + ".setCurrentListPosition("+value+")");
            }

        }
    }

    public class WindowXmlContentType
    {
        private string _name;
        //
        public WindowXmlContentType(string name)
        {
            this._name = name;
        }
        public string Name
        {
            get { return _name; }
        }
        //
        public static implicit operator string(WindowXmlContentType value)
        {
            return value._name;
        }
        //
        public static WindowXmlContentType Actors = new WindowXmlContentType("actors");
        public static WindowXmlContentType Addons = new WindowXmlContentType("addons");
        public static WindowXmlContentType Albums = new WindowXmlContentType("albums");
        public static WindowXmlContentType Artists = new WindowXmlContentType("artists");
        public static WindowXmlContentType Countries = new WindowXmlContentType("countries");
        public static WindowXmlContentType Directors = new WindowXmlContentType("directors");
        public static WindowXmlContentType Files = new WindowXmlContentType("files");
        public static WindowXmlContentType Games = new WindowXmlContentType("games");
        public static WindowXmlContentType Genres = new WindowXmlContentType("genres");
        public static WindowXmlContentType Images = new WindowXmlContentType("images");
        public static WindowXmlContentType Mixed = new WindowXmlContentType("mixed");
        public static WindowXmlContentType Movies = new WindowXmlContentType("movies");
        public static WindowXmlContentType MusicVideos = new WindowXmlContentType("musicvideos");
        public static WindowXmlContentType Playlists = new WindowXmlContentType("playlists");
        public static WindowXmlContentType Seasons = new WindowXmlContentType("seasons");
        public static WindowXmlContentType Sets = new WindowXmlContentType("sets");
        public static WindowXmlContentType Songs = new WindowXmlContentType("songs");
        public static WindowXmlContentType Studios = new WindowXmlContentType("studios");
        public static WindowXmlContentType Tags = new WindowXmlContentType("tags");
        public static WindowXmlContentType TvShows = new WindowXmlContentType("tvshows");
        public static WindowXmlContentType Videos = new WindowXmlContentType("videos");
        public static WindowXmlContentType Years = new WindowXmlContentType("years");

    }
}