using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public class Image : Control
    {
        private AspectRatioType _aspectRatio;
        private Colors _colorDiffuse;
        public Image(int x, int y, int width, int height, Colors color, Colors colorDiffuse, AspectRatioType aspectRatio = AspectRatioType.Stretch)
           : this(x, y, width, height, color.Texture, colorDiffuse, aspectRatio) { }
        public Image(int x, int y, int width, int height, string filename, Colors colorDiffuse, AspectRatioType aspectRatio = AspectRatioType.Stretch) 
            : base()
        {
            _aspectRatio = aspectRatio;
            _colorDiffuse = colorDiffuse;
            //
            Utils.Call(_name + " = xbmcgui.ControlImage(" + x + "," + y + "," + width + "," + height + ",'" + filename + "',"+Colors.ToParam("colorDiffuse", _colorDiffuse)+" aspectRatio = " + (int)_aspectRatio + ")");
        }
        public Image(int x, int y, int width, int height, string filename, AspectRatioType aspectRatio = AspectRatioType.Stretch) 
            : this(x, y, width, height, filename, Colors.None, aspectRatio) { }
        
        internal Image(string name) : base(name)
        {
        }

        public Colors ColorDiffuse
        {
            get
            {
                return _colorDiffuse;
            }
        }
        public AspectRatioType AspectRatio
        {
            get
            {
                return _aspectRatio;
            }
        }

    }
}