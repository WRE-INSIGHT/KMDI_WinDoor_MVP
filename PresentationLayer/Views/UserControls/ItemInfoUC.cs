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

        public string ItemName
        {
            get
            {
                return lbl_item.Text;
            }
            set
            {
                lbl_item.Text = value;
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
        public event EventHandler DefaultDescriptionClickEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void ItemInfoUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(this, ItemInfoUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> windoorModelBinding)
        {
            lbl_item.DataBindings.Add(windoorModelBinding["WD_name"]);
            lbl_dimension.DataBindings.Add(windoorModelBinding["WD_Dimension"]);
            lbl_desc.DataBindings.Add(windoorModelBinding["WD_description"]);
            this.DataBindings.Add(windoorModelBinding["WD_visibility"]);
            pbox_itemImage.DataBindings.Add(windoorModelBinding["WD_image"]);
            this.DataBindings.Add(windoorModelBinding["WD_Selected"]);
            //pboxSlidingTopView.DataBindings.Add(windoorModelBinding["WD_SlidingTopViewImage"]);
            //pboxSlidingTopView.DataBindings.Add(windoorModelBinding["WD_SlidingTopViewVisibility"]);
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

        private void lbl_item_MouseDown(object sender, MouseEventArgs e)
        {
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

        private void lbl_item_TextChanged(object sender, EventArgs e)
        {

        }

        private void defaultDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DefaultDescriptionClickEventRaised, e);
        }
    }
}
