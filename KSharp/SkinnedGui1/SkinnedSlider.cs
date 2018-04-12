using CRial.xbmcgui;
using System.IO;

namespace CRial.SkinnedGui
{
    public class SkinnedSlider : Slider
    {
        public SkinnedSlider(Orientation orientation = Orientation.Vertical) : base(-10, -10, 1, 1, 
                    Path.Combine(Skin.DefautSkin.Images, "Slider", "osd_slider_bg.png"),
                    Path.Combine(Skin.DefautSkin.Images, "Slider", "osd_slider_nibNF.png"),
                    Path.Combine(Skin.DefautSkin.Images, "Slider", "osd_slider_nib.png"), orientation: orientation)
        {
        }
    }
}