using CRial.xbmcgui;
using System.IO;

namespace CRial.SkinnedGui
{
    public class SkinnedList : List
    {
        public SkinnedList(Colors selectedColor, Colors shadowColor, int imageWidth = 10, int imageHeight = 10, int itemTextXOffset = 10, int itemTextYOffset = 2, int itemHeight = 27, int space = 2, Alignment alignmentY = Alignment.CENTER_Y) : 
            base(-10, -10, 1, 1, Path.Combine(Skin.DefautSkin.Images, "List", "MenuItemNF.png"),
            Path.Combine(Skin.DefautSkin.Images, "List", "MenuItemFO.png"),
            selectedColor,shadowColor,imageWidth:imageWidth,imageHeight:imageHeight,itemTextXOffset:itemTextXOffset,itemTextYOffset:itemTextYOffset,itemHeight:itemHeight,space:space,alignmentY:alignmentY)
        {}
        public SkinnedList(int imageWidth = 10, int imageHeight = 10, int itemTextXOffset = 10, int itemTextYOffset = 2, int itemHeight = 27, int space = 2, Alignment alignmentY = Alignment.CENTER_Y) :
           this(Colors.None, Colors.None, imageWidth: imageWidth, imageHeight: imageHeight, itemTextXOffset: itemTextXOffset, itemTextYOffset: itemTextYOffset, itemHeight: itemHeight, space: space, alignmentY: alignmentY)
        { }
    }
}