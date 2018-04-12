using CRial.Python;
using CRial.xbmcgui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.SkinnedGui
{
    public class SkinnedAbstractWindow : WindowBase
    {
        internal Dictionary<ActionId, System.Action> _actions_connected;
        internal Dictionary<Control, System.Action> _controls_connected;
        internal int _columns;
        internal int _grid_x;
        internal int _grid_y;
        internal int _height;
        internal int _rows;
        internal int _tile_height;
        internal int _tile_width;
        internal int _width;
        internal int _x;
        internal int _y;

        internal SkinnedAbstractWindow() : base()
        {
            _actions_connected = new Dictionary<ActionId, System.Action>();
            _controls_connected = new Dictionary<Control, System.Action>();
            OnAction += SkinnedAbstractWindow_OnAction;
        }
        public void connect(ActionId @event, System.Action callable)
        {
            disconnect(@event);
            _actions_connected.Add(@event, callable);
        }
        public void connect(Control @event, System.Action callable)
        {
            disconnect(@event);
            _controls_connected.Add(@event, callable);
        }
        public void disconnect(Control @event)
        {
            if (_controls_connected.ContainsKey(@event))
                _controls_connected.Remove(@event);
        }
        public void disconnect(ActionId @event)
        {
            if(_actions_connected.ContainsKey(@event))
                _actions_connected.Remove(@event);
        }
        public void connectEventList(List<object> events, System.Action function)
        {
            foreach (ActionId a in events.OfType<ActionId>())
                connect(a, function);
            foreach (Control a in events.OfType<Control>())
                connect(a, function);

        }
        public void setGeometry(int width_, int height_, int rows_, int columns_, int pos_x = -1, int pos_y = -1)
        {
            _width = width_;
            _height = height_;
            _rows = rows_;
            _columns = columns_;
            if (pos_x > 0 & pos_y > 0)
            {
                _x = pos_x;
                _y = pos_y;
            }
            else
            {
                _x = 640 - _width / 2;
                _y = 360 - _height / 2;
            }
            setGrid();
        }
        internal void setGrid()
        {
            _grid_x = _x;
            _grid_y = _y;
            _tile_width = _width / _columns;
            _tile_height = _height / _rows;
        }
        public void placeControl(Control control, int row, int column, int rowspan = 1, int columnspan = 1, int pad_x = 5, int pad_y = 5)
        {
            try
            {
                control.OnClick += Control_OnClick;
                int control_x = (_grid_x + _tile_width * column) + pad_x;
                int control_y = (_grid_y + (_tile_height * (row+1))) + pad_y;
                int control_width = _tile_width * columnspan - 2 * pad_x;
                int control_height = _tile_height * rowspan - 2 * pad_y;
                control.X = control_x;
                control.Y = control_y;
                control.Width = control_width;
                control.Height = control_height;
                addControl(control);
                //setAnimation(control);
            }
            catch (Exception ex)
            {
                throw new Exception("Window geometry is not defined! Call setGeometry first.");
            }

        }
        private void Control_OnClick(Control sender, EventArgs e)
        {
            if (_controls_connected.ContainsKey(sender))
                _controls_connected[sender]();
        }
        private void SkinnedAbstractWindow_OnAction(WindowBase sender, ActionEventArgs e)
        {
            if (_actions_connected.ContainsKey(e.Id))
                _actions_connected[e.Id]();
        }

        public int X
        {
            get
            {
                try
                {
                    return _x;
                }
                catch (Exception ex)
                {
                    throw new Exception("Window geometry is not defined! Call setGeometry first.");
                }
            }
        }
        public int Y
        {
            get
            {
                try
                {
                    return _y;
                }
                catch (Exception ex)
                {
                    throw new Exception("Window geometry is not defined! Call setGeometry first.");
                }
            }
        }
        public int WindowWidth
        {
            get
            {
                try
                {
                    return _width;
                }
                catch (Exception ex)
                {
                    throw new Exception("Window geometry is not defined! Call setGeometry first.");
                }
            }
        }
        public int WindowHeight
        {
            get
            {
                try
                {
                    return _height;
                }
                catch (Exception ex)
                {
                    throw new Exception("Window geometry is not defined! Call setGeometry first.");
                }
            }
        }
        public int Rows
        {
            get
            {
                try
                {
                    return _rows;
                }
                catch (Exception ex)
                {
                    throw new Exception("Window geometry is not defined! Call setGeometry first.");
                }
            }
        }
        public int Columns
        {
            get
            {
                try
                {
                    return _columns;
                }
                catch (Exception ex)
                {
                    throw new Exception("Window geometry is not defined! Call setGeometry first.");
                }
            }
        }
    }
}
