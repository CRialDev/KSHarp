using CRial.xbmcgui;

namespace CRial.SkinnedGui
{
    public class SkinnedImage : Image
    {
        public SkinnedImage(string filename,Colors colorDiffuse ,AspectRatioType aspectRatio= AspectRatioType.Stretch) 
            :base(-10, -10, 1, 1,filename,colorDiffuse, aspectRatio:aspectRatio)
        { }
        public SkinnedImage(string filename, AspectRatioType aspectRatio = AspectRatioType.Stretch) 
            : this(filename,Colors.None, aspectRatio: aspectRatio)
        { }

    }
}