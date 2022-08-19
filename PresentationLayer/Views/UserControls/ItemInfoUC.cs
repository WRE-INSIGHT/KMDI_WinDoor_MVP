using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ItemInfoUC : UserControl, IItemInfoUC
    {
        private bool _wdSelected;
        public bool WD_Selected
        {
            get
            {
                return _wdSelected;
            }

            set
            {
                _wdSelected = value;
                if (_wdSelected)
                {
                    lbl_item.ForeColor = Color.Blue;
                }
                else
                {
                    lbl_item.ForeColor = Color.Black;
                }
            }
        }
       
        public int PboxItemImagerHeight
        {
            get
            {
                return pbox_itemImage.Height;
            }

            set
            {
                pbox_itemImage.Height = value;
            }
        }

        public ItemInfoUC()
        {
            InitializeComponent();
        }

        public event EventHandler ItemInfoUCLoadEventRaised;
        public event MouseEventHandler lblItemMouseDoubleClickEventRaised;
        public event MouseEventHandler lblItemMouseMoveEventRaised;
        public event MouseEventHandler lblItemMouseDownEventRaised;
        public event MouseEventHandler lblItemMouseUpEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void ItemInfoUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(this, ItemInfoUCLoadEventRaised, e);
            AllowDrag = true;
        }

        public void ThisBinding(Dictionary<string, Binding> windoorModelBinding)
        {
            lbl_item.DataBindings.Add(windoorModelBinding["WD_name"]);
            lbl_dimension.DataBindings.Add(windoorModelBinding["WD_Dimension"]);
            lbl_desc.DataBindings.Add(windoorModelBinding["WD_description"]);
            this.DataBindings.Add(windoorModelBinding["WD_visibility"]);
            pbox_itemImage.DataBindings.Add(windoorModelBinding["WD_image"]);
            this.DataBindings.Add(windoorModelBinding["WD_Selected"]);
            pboxSlidingTopView.DataBindings.Add(windoorModelBinding["WD_SlidingTopViewImage"]);
            pboxSlidingTopView.DataBindings.Add(windoorModelBinding["WD_SlidingTopViewVisibility"]);
            //pbox_itemImage.DataBindings.Add(windoorModelBinding["WD_pboxImagerHeight"]);
        }

        private void lbl_item_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, lblItemMouseDoubleClickEventRaised, e);
            }
        }

        private void lbl_item_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private bool _isDragging = false;
        private int _mX = 0;
        private int _mY = 0;
        private int _DDradius = 40;
        public bool AllowDrag { get; set; }

        public string WD_Item
        {
            get
            {
                return lbl_item.Text;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private void lbl_item_MouseDown(object sender, MouseEventArgs e)
        {
            //this.Focus();
            //_mX = e.X;
            //_mY = e.Y;
            //this._isDragging = false;
            if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, lblItemMouseDownEventRaised, e);
            }
        }

        private void lbl_item_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, lblItemMouseMoveEventRaised, e);
            }
            //if (!_isDragging)
            //{
            //    // This is a check to see if the mouse is moving while pressed.
            //    // Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
            //    if (e.Button == MouseButtons.Left && _DDradius > 0 && this.AllowDrag)
            //    {
            //        int num1 = _mX - e.X;
            //        int num2 = _mY - e.Y;
            //        if (((num1 * num1) + (num2 * num2)) > _DDradius)
            //        {
            //            DoDragDrop(this, DragDropEffects.All);
            //            _isDragging = true;
            //            return;
            //        }
            //    }
            //}
        }

        private void lbl_item_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EventHelpers.RaiseMouseEvent(sender, lblItemMouseUpEventRaised, e);
            }
            //_isDragging = false;
        }

        public UserControl GetItemInfo()
        {
            return this;
        }
    }
}
