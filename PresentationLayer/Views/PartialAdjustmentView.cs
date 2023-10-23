using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class PartialAdjustmentView : Form, IPartialAdjustmentView
    {
        public PartialAdjustmentView()
        {
            InitializeComponent();
        }

        public Panel GetPanelHeader()
        {
            return _pnlHeader;
        }
        public Panel GetPanelBody()
        {
            return _pnlBody;
        }

        public Label GetPrevItemLbl()
        {
            return lbl_prevItem;
        }
        public Label GetCurrItemLbl()
        {
            return lbl_currItem;
        }
        public Panel GetItemListPnl()
        {
            return pnl_itemList;
        }
        public CheckedListBox GetItemListCheckListBox()
        {
            return chklstbx_itemList;
        }
        public void ShowPartialAdjusmentView()
        {
            this.ShowDialog();
        }

        public void ClosePartialAdjustmentView()
        {
            this.Close();
        }

        public Form GetThis()
        {
            return this;
        }

        public event EventHandler _printToolStripBtnClickEventRaised;  
        public event EventHandler _partialAdjustmentViewLoadEventRaised;
        public event EventHandler _btn_addItem_ClickEventRaised;
        public event EventHandler _ItemPanelToolstripBtn_ClickEventRaised;
        public event EventHandler _itemSortToolStrpBtn_ClickEventRaised;

        private void _printToolStripBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _printToolStripBtnClickEventRaised, e);
        }

        private void PartialAdjustmentView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _partialAdjustmentViewLoadEventRaised, e);
        }

        private void _btn_addItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _btn_addItem_ClickEventRaised,e);
        }

        private void _ItemPanelToolstripBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _ItemPanelToolstripBtn_ClickEventRaised, e);
        }

        private void _itemSortToolStrpBtn_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, _itemSortToolStrpBtn_ClickEventRaised, e);
        }
    }
}
