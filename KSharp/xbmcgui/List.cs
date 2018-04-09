using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcgui
{
    public class List : Control
    {
        private string _buttonTexture;
        private object _buttonFocusTexture;
        private Colors _selectedColor;
        private int _imageWidth;
        private int _imageHeight;
        private int _itemTextXOffset;
        private int _itemTextYOffset;
        private Alignment _alignmentY;
        private Colors _shadowColor;
        #region Constructor
        //
        public List(int x, int y, int width, int height, string label, string buttonTexture, string buttonFocusTexture, Colors selectedColor, Colors shadowColor, int imageWidth = 10, int imageHeight = 10, int itemTextXOffset = 10, int itemTextYOffset = 2, int itemHeight = 27, int space = 2, Alignment alignmentY = Alignment.CENTER_Y)
        : base()
        {
            _buttonTexture = buttonTexture;
            _buttonFocusTexture = buttonFocusTexture;
            _selectedColor = selectedColor;
            _imageWidth = imageWidth;
            _imageHeight = imageHeight;
            _itemTextXOffset = itemTextXOffset;
            _itemTextYOffset = itemTextYOffset;
            _alignmentY = alignmentY;
            _shadowColor = shadowColor;
            //
            Utils.Call(_name + " = xbmcgui.ControlList(" + x + "," + y + "," + width + "," + height + ",'" + label + "','buttonTexture' = '" + buttonTexture + "','buttonFocusTexture' = '" + buttonFocusTexture + "','selectedColor' = '" + selectedColor + "','imageWidth' = " + imageWidth + ",'imageHeight' = " + imageHeight + ",'itemTextXOffset' = " + itemTextXOffset + ",'itemTextYOffset' = " + itemTextYOffset + ",'itemHeight' = " + itemHeight + ",'space' = " + space + ",'alignmentY' = " + alignmentY + ",'shadowColor' = '" + shadowColor + "')");
        }
        public List(int x, int y, int width, int height, string label, Colors selectedColor, Colors shadowColor, int imageWidth = 10, int imageHeight = 10, int itemTextXOffset = 10, int itemTextYOffset = 2, int itemHeight = 27, int space = 2, Alignment alignmentY = Alignment.CENTER_Y)
        : base()
        {
            _buttonTexture = null;
            _buttonFocusTexture = null;
            _selectedColor = selectedColor;
            _imageWidth = imageWidth;
            _imageHeight = imageHeight;
            _itemTextXOffset = itemTextXOffset;
            _itemTextYOffset = itemTextYOffset;
            _alignmentY = alignmentY;
            _shadowColor = shadowColor;
            //
            Utils.Call(_name + " = xbmcgui.ControlList(" + x + "," + y + "," + width + "," + height + ",'" + label + "','selectedColor' = '" + selectedColor + "','imageWidth' = " + imageWidth + ",'imageHeight' = " + imageHeight + ",'itemTextXOffset' = " + itemTextXOffset + ",'itemTextYOffset' = " + itemTextYOffset + ",'itemHeight' = " + itemHeight + ",'space' = " + space + ",'alignmentY' = " + alignmentY + ",'shadowColor' = '" + shadowColor + "')");
        }
        public List(int x, int y, int width, int height, string label)
        : this(x, y, width, height, label, Colors.Blue, Colors.Transparent) { }
        internal List(string name) : base(name)
        {
        }
        //
        #endregion
        public string ButtonTexture
        {
            get
            {
                return _buttonTexture;
            }
        }
        public object ButtonFocusTexture
        {
            get
            {
                return _buttonFocusTexture;
            }
        }
        public Colors SelectedColor
        {
            get
            {
                return _selectedColor;
            }
        }
        public int ImageWidth
        {
            get
            {
                return _imageWidth;
            }
        }
        public int ImageHeight
        {
            get
            {
                return _imageHeight;
            }
        }
        public int ItemTextXOffset
        {
            get
            {
                return _itemTextXOffset;
            }
        }
        public int ItemTextYOffset
        {
            get
            {
                return _itemTextYOffset;
            }
        }
        public Alignment AlignmentY
        {
            get
            {
                return _alignmentY;
            }
        }
        public Colors ShadowColor
        {
            get
            {
                return _shadowColor;
            }
        }
        public void addItem(string item, bool sendMessage = true)
        {
            Utils.Call(_name + ".addItem('" + item + "', sendMessage = " + sendMessage.ToString() + " )");
        }
        public void addItem(ListItem item, bool sendMessage = true)
        {
            Utils.Call(_name + ".addItem(" + item._name + ", sendMessage = " + sendMessage.ToString() + " )");
        }
        public void addItems(List<object> items)
        {
            foreach (string i in items.OfType<string>())
            {
                addItem(i);
            }
            foreach (ListItem i in items.OfType<ListItem>())
            {
                addItem(i);
            }

        }
        public int SelectPosition
        {
            set
            {
                Utils.Call(_name + ".selectItem(" + value + ")");
            }
            get
            {
                return Utils.Call<int>(_name + ".getSelectedPosition()");
            }
        }
        public void reset()
        {
            Utils.Call(_name + ".reset()");
        }
        public Spin getSpinControl()
        {
            string spin = "sc_" + Utils.GenerateId();
            Utils.Call(spin + " = " + _name + ".getSpinControl()");
            return new Spin(spin);
        }
        public void setImageDimensions(int imageWidth, int imageHeight)
        {
            Utils.Call(_name + ".setImageDimensions(" + imageWidth + ", " + imageHeight + ")");
        }
        public int ItemHeight
        {
            set
            {
                Utils.Call(_name + ".setItemHeight(" + value + ")");
            }
            get
            {
                return Utils.Call<int>(_name + ".getItemHeight()");
            }
        }
        public void setPageControlVisible(bool visible)
        {
            Utils.Call(_name + ".setPageControlVisible(" + visible.ToString() + ")");
        }
        public int Space
        {
            set
            {
                Utils.Call(_name + ".setSpace(" + value + ")");
            }
            get
            {
                return Utils.Call<int>(_name + ".getSpace()");
            }
        }
        public ListItem getSelectedItem()
        {
            string item = "li_" + Utils.GenerateId();
            Utils.Call(item + " = " + _name + ".getSelectedItem()");
            return new ListItem(item);
        }
        public long Size()
        {
            return Utils.Call<long>(_name + ".size()");
        }
        public ListItem getListItem()
        {
            string item = "li_" + Utils.GenerateId();
            Utils.Call(item + " = " + _name + ".getListItem()");
            return new ListItem(item);
        }
        public void removeItem(int index)
        {
            Utils.Call(_name + ".removeItem(" + index + ")");
        }
    }
}