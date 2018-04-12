using CRial.xbmcgui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.SkinnedGui
{
    public class SkinnedWindow : SkinnedAbstractWindow
    {
        internal Skin _skin = Skin.DefautSkin;
        private Image _background;
        private string _background_img;
        private Image _title_background;
        private string _title_background_img;
        private Label _title_bar;
        private Button _window_close_button;
        private int _win_padding;

        public SkinnedWindow() : base()
        {
            
        }
        internal void setFrame(string title)
        {
            _background_img = _skin.background_img;
            _title_background_img = _skin.title_background_img;
            _background = new Image(-10, -10, 1, 1, _background_img);
            addControl(_background);
            //self.setAnimation(self.background)
            _title_background = new Image(-10, -10, 1, 1, _title_background_img);
            addControl(_title_background);
            //self.setAnimation(self.title_background)
            _title_bar = new Label(-10, -10, 1, 1, title, _skin.header_text_color, Colors.Transparent, alignment: _skin.header_align, font: "font13_title");
            addControl(_title_bar);
            //self.setAnimation(self.title_bar)
            _window_close_button = new Button(-100, -100, _skin.close_btn_width, _skin.close_btn_height, "", _skin.close_button_focus, _skin.close_button_no_focus, Colors.Transparent, Colors.Transparent, Colors.Transparent, Colors.Transparent);
            _window_close_button.OnClick += _window_close_button_OnClick;
            addControl(_window_close_button);
            this.OnAction += SkinnedWindow_OnAction;
            //self.setAnimation(self.window_close_button)
        }

        private void SkinnedWindow_OnAction(WindowBase sender, ActionEventArgs e)
        {
            if(e.Id == ActionId.NAV_BACK)
            {
                close();
            }
        }

        private void _window_close_button_OnClick(Control sender, EventArgs e)
        {
            close();
        }

        public void setGeometry(int width_, int height_, int rows_, int columns_, int pos_x = -1, int pos_y = -1, int padding = 5)
        {
            _win_padding = padding;
            base.setGeometry(width_, height_, rows_, columns_, pos_x, pos_y);
            _background.X = _x;
            _background.Y = _y;
            _background.Width = _width;
            _background.Height = _height+_tile_height;
            _title_background.X = _x + _skin.x_margin;
            _title_background.Y = _y + _skin.y_margin + _skin.title_back_y_shift;
            _title_background.Width = _width - 2 * _skin.x_margin;
            _title_background.Height = _skin.header_height;
            _title_bar.X = _x + _skin.x_margin + _skin.title_bar_x_shift;
            _title_bar.Y = _y + _skin.y_margin + _skin.title_bar_y_shift;
            _title_bar.Width = _width - 2 * _skin.x_margin;
            _title_bar.Height = _skin.header_height;
            _window_close_button.X = _x + _width - _skin.close_btn_x_offset;
            _window_close_button.Y = _y + _skin.y_margin + _skin.close_btn_y_offset;
        }
        public new void setGrid()
        {
            _grid_x = _x + _skin.x_margin + _win_padding;
            _grid_y = _y + _skin.y_margin + _skin.title_back_y_shift + _skin.header_height + _win_padding;
            _tile_width = (_width - 2 * (_skin.x_margin + _win_padding)) / _columns;
            _tile_height = ((_height - _skin.header_height - _skin.title_back_y_shift - 2 * (_skin.y_margin + _win_padding)) / _rows);
        }
        public string WindowTitle
        {
            set
            {
                _title_bar.label = value;
            }
            get
            {
                return _title_bar.label;
            }
        }
    }
}
