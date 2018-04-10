using CRial;
using CRial.xbmcgui;
using CRial.xbmcrpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibraryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyAddon add = new MyAddon(args);
        }
    }
    public class MyAddon : KSharp
    {
        public MyAddon(string[] args) : base()
        {
            DialogProgress dp = new DialogProgress();
            dp.create("VideoLibrary Example", "Retrieve List of Movies");
            VideoLibrary vl = new VideoLibrary();
            List<Movie> mov = vl.GetMovies(0,5);
            dp.update(50, "Retrieve List of TVShow");
            List<TVShow> tv = vl.GetTVShows();
            StringBuilder textview = new StringBuilder("Movies List :");
            dp.update(80, "Create List");
            foreach (Movie s in mov)
            {
                textview.AppendLine("    - "+s.Label + " (" + s.Year + ")");
            }
            textview.AppendLine("TVShow List:");
            foreach (TVShow s in tv)
            {
                textview.AppendLine("    - " + s.Label + " (" + s.Year + ")");
            }
            dp.update(100, "Finish succesful");
            dp.close();
            Dialog.TextViewer("VideoLibrary Example", textview.ToString());
            Stop();
        }
    }
}
