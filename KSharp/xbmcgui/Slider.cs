using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public enum Orientation : int
    {
        Horizontal = 0,
        Vertical = 1
    }
    public class Slider: Control
    {
        private string _textureback;
        private string _texture;
        private string _texturefocus;
        private Orientation _orientation;
        public Slider(int x, int y, int width, int height, string textureback, string texture, string texturefocus,Orientation orientation= Orientation.Vertical)
        : base()
        {
            _textureback = textureback;
            _texture = texture;
            _texturefocus = texturefocus;
            _orientation = orientation;
            //
            Utils.Call(_name + " = xbmcgui.ControlButton(" + x + "," + y + "," + width + "," + height + ", textureback = '" + textureback + "', texture = '" + texture + "', texturefocus = '" + texturefocus + "', orientation = " + (int)orientation + ")");
        }
        public Slider(int x, int y, int width, int height, Orientation orientation = Orientation.Vertical)
                : base()
        {
            _textureback = null;
            _texture = null;
            _texturefocus = null;
            _orientation = orientation;
            //
            Utils.Call(_name + " = xbmcgui.ControlButton(" + x + "," + y + "," + width + "," + height + ", orientation = " + (int)orientation + ")");
        }
        public string TextureBack
        {
            get
            {
                return _textureback;
            }
        }
        public string Texture
        {
            get
            {
                return _texture;
            }
        }
        public string TextureFocus
        {
            get
            {
                return _texturefocus;
            }
        }
        public Orientation Orientation
        {
            get
            {
                return _orientation;
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
                Utils.Call(_name + ".setPercent(" + value + ")");
            }
        }
    }
}
