using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public class Progress : Control
    {
        private string _texturebg;
        private string _textureleft;
        private string _texturemid;
        private string _textureoverlay;
        private string _textureright;
        public Progress(int x, int y, int width, int height, Colors Colorbg, Colors Colorleft, Colors Colormid, Colors Colorright, Colors Coloroverlay)
       : this(x, y, width, height, Colorbg.Texture, Colorleft.Texture, Colormid.Texture, Colorright.Texture, Coloroverlay.Texture) { }
        public Progress(int x, int y, int width, int height, string texturebg, string textureleft, string texturemid, string textureright, string textureoverlay)
        : base()
        {
            _texturebg = texturebg;
            _textureleft = textureleft;
            _texturemid = texturemid;
            _textureright = textureright;
            _textureoverlay = textureoverlay;
            //
            Utils.Call(_name + " = xbmcgui.ControlButton(" + x + "," + y + "," + width + "," + height + ", texturebg = '" + texturebg + "', textureleft = '" + textureleft + "', texturemid = '" + texturemid + "', textureright = '" + textureright + "', textureoverlay = '" + textureoverlay + "')");
        }
        public Progress(int x, int y, int width, int height)
        : base()
        {
            _texturebg = null;
            _textureleft = null;
            _texturemid = null;
            _textureright = null;
            _textureoverlay = null;
            //
            Utils.Call(_name + " = xbmcgui.ControlButton(" + x + "," + y + "," + width + "," + height + ")");
        }
        public string TextureBg
        {
            get
            {
                return _texturebg;
            }
        }
        public string TextureLeft
        {
            get
            {
                return _textureleft;
            }
        }
        public string TextureMid
        {
            get
            {
                return _texturemid;
            }
        }
        public string TextureRight
        {
            get
            {
                return _textureright;
            }
        }
        public string TextureOverlay
        {
            get
            {
                return _textureoverlay;
            }
        }
        public float Percent
        {
            get
            {
                return Utils.Call<float>(_name + ".getPercent()");
            }
            set
            {
                Utils.Call(_name + ".setPercent("+value+")");
            }
        }
    }
}
