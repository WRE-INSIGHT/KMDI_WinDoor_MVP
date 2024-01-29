using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class SortItemUC : UserControl, ISortItemUC
    {
        public SortItemUC()
        {
            InitializeComponent();
        }
        public event EventHandler SortItemUCLoadEventRaised;
        public event MouseEventHandler cbItemMouseMoveEventRaised;
        public event MouseEventHandler cbItemMouseDownEventRaised;
        public event MouseEventHandler cbItemMouseUpEventRaised;
        public event EventHandler DeleteToolStripButtonClickEventRaised;
        public event EventHandler DuplicateToolStripButtonClickEventRaised;
        public event EventHandler cbitem_CheckedChangedEventRaised;

        public string ItemName
        {
            get
            {
                return cb_item.Text;
            }
            set
            {
                cb_item.Text = value;
            }
        }
        public PictureBox GetPboxItemImage()
        {
            return pboxItemImage;
        }
        public string itemDimension
        {
            get
            {
                return lbl_dimension.Text;
            }
            set
            {
                lbl_dimension.Text = value;
            }
        }
        public string itemDesc
        {
            get
            {
                return rtboxDesc.Text;
            }
            set
            {
                rtboxDesc.Text = value;
            }
        }
        private bool _itemSelected;
        public bool itemSelected
        {
            get
            {
                return _itemSelected;
            }

            set
            {
                _itemSelected = value;
                if (_itemSelected)
                {
                    cb_item.ForeColor = Color.Blue;
                }
                else
                {
                    cb_item.ForeColor = Color.Black;
                }
            }
        }

        public bool itemChecked
        {
            get
            {
                return cb_item.Checked;
            }
        }

        private void SortItemUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SortItemUCLoadEventRaised, e);
        }

        private void cb_item_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, cbItemMouseMoveEventRaised, e);
        }

        private void cb_item_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, cbItemMouseUpEventRaised, e);
        }

        private void cb_item_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, cbItemMouseDownEventRaised, e);
        }

        public UserControl GetSortItem()
        {
            return this;
        }
       
        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DuplicateToolStripButtonClickEventRaised, e);
        }

        private void cb_item_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cbitem_CheckedChangedEventRaised, e);
        }

        private void pboxItemImage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(panelSort.Height > 100)
            {
                this.Height = 28;
            }
            else
            {
                this.Height = 141;
            }
        
        }
    }
}
