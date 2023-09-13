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
    public partial class PartialAdjustmenItemDisabledUC : UserControl, IPartialAdjustmenItemDisabledUC
    {
        public PartialAdjustmenItemDisabledUC()
        {
            InitializeComponent();
        }

        public Panel PanelBody()
        {
            return pnl_BtnHolder;
        }

        public event EventHandler PartialAdjustmenItemDisabledUC_LoadEventRaised;
        public event EventHandler btn_Yes_ClickEventRaised;
        public event EventHandler btn_Cancel_ClickEventRaised;
        public event EventHandler PartialAdjustmenItemDisabledUC_ResizeEventRaised;

        public void ItemInfoDisabledBringToFront()
        {
             this.BringToFront();
        }

        public void ItemInfoDisabledSendToBack()
        {
            this.SendToBack();
        }

        public void InvalidateItemDisabled()
        {
            this.Invalidate();
        }

        public UserControl GetPartialAdjustmentItemDisableUC()
        {
            return this;
        }
        
        private void PartialAdjustmenItemDisabledUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PartialAdjustmenItemDisabledUC_LoadEventRaised, e);
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_Yes_ClickEventRaised, e);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_Cancel_ClickEventRaised, e);

        }

        private void PartialAdjustmenItemDisabledUC_Resize(object sender, EventArgs e)
        {

        }
    }
}
