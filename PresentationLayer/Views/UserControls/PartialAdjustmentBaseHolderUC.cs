using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class PartialAdjustmentBaseHolderUC : UserControl, IPartialAdjustmentBaseHolderUC
    {
        public PartialAdjustmentBaseHolderUC()
        {
            InitializeComponent();
        }

        public void PABaseHolderDispose()
        {
            this.Dispose();
        }

        public Button PABaseHolderExpandBtn()
        {
            return btn_Expnd;
        }
        public Button PABaseHolderAddItemQtyBtn()
        {
            return btn_addItemQty;
        }
        public Label PABaseHolderItemName()
        {
            return lbl_ItemNo;
        }
        public Panel PABaseHolderPanelTitle()
        {
            return pnl_BaseHolderPnl;
        }
        public Panel PABaseHolderPanelBody()
        {
            return pnl_BaseHolderBody;
        }

        public void PABaseHolderBringToFront()
        {
            this.BringToFront();
        }
        public void PABaseHolderSendToBack()
        {
            this.SendToBack();
        }
        public void PABaseHolderInvalidate()
        {
            this.Invalidate();
        }

        public UserControl GetPABaseHolderUC()
        {
            return this;
        }

        public event EventHandler PartialAdjustmentBaseHolderUC_LoadEventRaised;
        public event EventHandler btn_Expnd_ClickEventRaised;
        public event EventHandler btn_addItemQty_ClickEventRaised;
        public event EventHandler btn_DeleteItem_ClickEventRaised;

        private void PartialAdjustmentBaseHolderUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PartialAdjustmentBaseHolderUC_LoadEventRaised,e);
        }

        private void btn_Expnd_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_Expnd_ClickEventRaised, e);
        }

        private void btn_addItemQty_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_addItemQty_ClickEventRaised, e);
        }

        private void btn_DeleteItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_DeleteItem_ClickEventRaised, e);
        }
    }
}
