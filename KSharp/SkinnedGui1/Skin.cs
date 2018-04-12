using CRial.xbmcaddon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.SkinnedGui
{
    public class Skin
    {
        public static Skin DefautSkin;
        //
        public static Skin Estuary
        {
            get
            {
                Skin ret = new Skin();
                ret._texture_dir = Path.Combine(new Addon().getAddonInfo("path"),"KSharp", "Skins", "textures");
                ret.Images = Path.Combine(ret._texture_dir, "estuary");
                ret.x_margin = 0;
                ret.y_margin = 0;
                ret.title_bar_x_shift = 20;
                ret.title_bar_y_shift = 8;
                ret.title_back_y_shift = 0;
                ret.header_height = 45;
                ret.close_btn_width = 35;
                ret.close_btn_height = 30;
                ret.close_btn_x_offset = 50;
                ret.close_btn_y_offset = 7;
                ret.header_align = 0;
                ret.header_text_color = Colors.Transparent;
                ret.background_img = Path.Combine(ret.Images, "AddonWindow", "ContentPanel.png");
                ret.title_background_img = Path.Combine(ret.Images, "AddonWindow", "dialogheader.png");
                ret.close_button_focus = Path.Combine(ret.Images, "AddonWindow", "DialogCloseButton-focus.png");
                ret.close_button_no_focus = Path.Combine(ret.Images, "AddonWindow", "DialogCloseButton.png");
                ret.main_bg_img = Path.Combine(ret.Images, "AddonWindow", "SKINDEFAULT.png");

                return ret;
            }
        }
        //
        public string Images;
        internal string background_img;
        internal int close_btn_height;
        internal int close_btn_width;
        internal int close_btn_x_offset;
        internal int close_btn_y_offset;
        internal string close_button_focus;
        internal string close_button_no_focus;
        internal Alignment header_align;
        internal int header_height;
        internal Colors header_text_color;
        internal string title_background_img;
        internal int title_back_y_shift;
        internal int title_bar_x_shift;
        internal int title_bar_y_shift;
        internal int x_margin;
        internal int y_margin;
        internal string _texture_dir;
        internal string main_bg_img;
    }
}
