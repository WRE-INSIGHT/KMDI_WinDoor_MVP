using CommonComponents;
using System;
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
        public event MouseEventHandler lblItemMouseMoveEventRaised;
        public event MouseEventHandler lblItemMouseDownEventRaised;
        public event MouseEventHandler lblItemMouseUpEventRaised;
        public event EventHandler DeleteToolStripButtonClickEventRaised;
        public event EventHandler DuplicateToolStripButtonClickEventRaised;

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
        private void SortItemUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SortItemUCLoadEventRaised, e);
        }

        private void lbl_item_MouseMove(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, lblItemMouseMoveEventRaised, e);
        }

        private void lbl_item_MouseUp(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, lblItemMouseUpEventRaised, e);
        }

        private void lbl_item_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(sender, lblItemMouseDownEventRaised, e);
        }

        public UserControl GetSortItem()
        {
            return this;
        }

        private void lbl_item_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Name);
        }
        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, DuplicateToolStripButtonClickEventRaised, e);
        }
    }
}
